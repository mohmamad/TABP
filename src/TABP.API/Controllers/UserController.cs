using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs;
using TABP.API.Models;
using TABP.Application.CQRS.Commands;
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

            if (!ModelState.IsValid)  return BadRequest("Invalid email address");

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
    }
}
