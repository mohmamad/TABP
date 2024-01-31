using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs;
using TABP.Application.CQRS.Commands;
using TABP.Application.CQRS.Queries;
using TABP.Domain.Entities;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("{hotelId}")]
        public async Task<ActionResult<RoomDto>> AddRoom(AddRoomDto addRoomDto, Guid hotelId)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddRoomCommand
                {
                    Capacity = addRoomDto.Capacity,
                    HotelId = hotelId,
                    Price = addRoomDto.Price,
                    RoomNumber = addRoomDto.RoomNumber,
                    RoomTypeId = addRoomDto.RoomTypeId,
                });

                if (result.IsSuccess)
                {
                    var roomDto = _mapper.Map<RoomDto>(result.Data);
                    return Ok(roomDto);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }

            }
            else
            {
                return Unauthorized();
            }
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoom
            (
                [FromQuery] Guid? roomId,
                [FromQuery] Guid? HotelId,
                [FromQuery] Guid? roomTypeId,
                [FromQuery] int? roomNumber,
                [FromQuery] double? price,
                [FromQuery] int? capacity,
                [FromQuery] bool? isAvaiable,
                [FromQuery] int pageSize = 30,
                [FromQuery] int page = 1
            )
        {
            var result = await _mediator.Send(new GetRoomsQuery
            {
                RoomId = roomId,
                HotelId = HotelId,
                RoomTypeId = roomTypeId,
                RoomNumber = roomNumber,
                Price = price,
                Capacity = capacity,
                PageSize = pageSize,
                Page = page
            });

            var roomDto = _mapper.Map<IEnumerable<RoomDto>>(result.Data);
            return Ok(roomDto);

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

        [HttpPatch("{roomId}")]
        public async Task<ActionResult> UpdateRoom
            (
            Guid roomId,
            JsonPatchDocument<UpdateRoomDto> RoomJsonPatch
            )
        {
            var result = await _mediator.Send(new GetRoomByIdQuery
            {
                RoomId = roomId
            });
            if (!result.IsSuccess) return NotFound();

            var room = result.Data;
            var roomDtoForUpdate = _mapper.Map<UpdateRoomDto>(room);
            RoomJsonPatch.ApplyTo(roomDtoForUpdate, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(roomDtoForUpdate))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(roomDtoForUpdate, room);

            await _mediator.Send(new SaveRoomChangesCommand());

            return NoContent();
        }
    }
}
