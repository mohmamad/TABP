using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.RoomDtos;
using TABP.Application.CQRS.Commands.RoomCommands;
using TABP.Application.CQRS.Queries.RoomQueries;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomTypeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomTypeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("roomType")]
        public async Task<ActionResult<RoomTypeDto>> AddRoomType(AddRoomTypeDto addRoomTypeDto)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddRoomTypeCommand
                {
                    Type = addRoomTypeDto.Type,
                });
                var roomTypeDto = _mapper.Map<RoomTypeDto>(result.Data);
                return Ok(roomTypeDto);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("roomType/{roomtypeId}")]
        public async Task<ActionResult<RoomTypeDto>> GetRoomTypeByRoomId(Guid roomTypeId)
        {
            var result = await _mediator.Send(new GetRoomTypeByIdQuery
            {
                RoomTypeId = roomTypeId
            });
            var roomTypeDto = _mapper.Map<RoomTypeDto>(result.Data);
            return Ok(roomTypeDto);
        }
    }
}
