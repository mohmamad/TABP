using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.HotelDtos;
using TABP.API.DTOs.UserDtos;
using TABP.API.Models;
using TABP.Application.CQRS.Commands.UserCommands;
using TABP.Application.CQRS.Queries.UserQueries;
using TABP.Domain.Entities;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserDto>>> AddUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            if (!ModelState.IsValid) return BadRequest("Invalid email address");

            var result = await _mediator.Send(new CreateUserCommand
            {
                User = user
            });

            if (result.IsSuccess)
            {
                var userDtoToReturn = _mapper.Map<UserDto>(result.Data);
                return Ok(userDtoToReturn);
            }
            else return BadRequest(result.ErrorMessage);
        }

        [HttpPost("/login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AuthenticateUser(UserCredentials userCredentials)
        {
            var result = await _mediator.Send(new AuthenticateUserCommand
            {
                UserCredentials = userCredentials
            });

            if (result.IsSuccess) return Ok(result.Data);

            else return Unauthorized(result.ErrorMessage);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser
            (
                [FromQuery] Guid? userId,
                [FromQuery] string? firstName,
                [FromQuery] string? lastName,
                [FromQuery] string? email,
                [FromQuery] DateTime? birthDate,
                [FromQuery] int? userLevel,
                [FromQuery] int pageSize = 30,
                [FromQuery] int page = 1
            )
        {
            var result = await _mediator.Send(new GetUsersQuery
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                BirthDate = birthDate,
                UserLevel = userLevel,
                PageSize = pageSize,
                Page = page
            });

            var userDto = _mapper.Map<IEnumerable<UserDto>>(result.Data);

            return Ok(userDto);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"));
            var userIdFromToken = new Guid();
            if (userIdClaim != null)
            {
                userIdFromToken = Guid.Parse(userIdClaim.Value);
            }
            else
            {
                return Unauthorized();
            }
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if (userLevel == "2" || userIdFromToken == userId)
            {
                await _mediator.Send(new DeleteUserByIdCommand
                {
                    UserId = userId
                });
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpPost("ForgetPasswordDto")]
        public async Task<ActionResult> GenerateForgetPasswordCode(ForgetPasswordDto forgetPasswordDto)
        {

            var result = await _mediator.Send(new GenerateForgetPasswordCodeCommand { Email = forgetPasswordDto.Email });

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPost("checkCode/{code}")]
        public async Task<ActionResult<string>> CheckIfCodeCorrect(string code)
        {
            var result = await _mediator.Send(new CheckCodeCommand { Code = code });

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.ErrorMessage);
        }


        [HttpPatch("{userId}")]
        public async Task<ActionResult> ResetPassword(Guid userId, JsonPatchDocument<UpdateUserDto> userJsonPatch)
        {
            var result = await _mediator.Send(new GetUsersQuery
            {
                UserId = userId,
                FirstName = null,
                LastName = null,
                Email = null,
                BirthDate = null,
                UserLevel = null,
                Page = 1,
                PageSize = 1
            });

            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
            }
            var user = result.Data;
            var userDtoForUpdate = _mapper.Map<UpdateUserDto>(user);
            userJsonPatch.ApplyTo(userDtoForUpdate, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(userDtoForUpdate))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userDtoForUpdate, user);
            await _mediator.Send(new SaveChangesCommand());
            
            return NoContent();
        }

    }
}
