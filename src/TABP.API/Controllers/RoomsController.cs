using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.RoomDtos;
using TABP.Application.CQRS.Commands.RoomCommands;
using TABP.Application.CQRS.Queries.FeaturedDeals;
using TABP.Application.CQRS.Queries.RoomQueries;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoom
            (
                [FromQuery] Guid? roomId,
                [FromQuery] Guid? HotelId,
                [FromQuery] Guid? roomTypeId,
                [FromQuery] int? roomNumber,
                [FromQuery] double? price,
                [FromQuery] int? capacity,
                [FromQuery] double? maxPrice,
                [FromQuery] double? minPrice,
                [FromQuery] DateTime? startDate,
                [FromQuery] DateTime? endDate,
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
                MaxPrice = maxPrice,
                MinPrice = minPrice,
                StartDate = startDate,
                EndDate = endDate,
                PageSize = pageSize,
                Page = page
            });
            if (result.IsSuccess)
            {
                var roomDto = _mapper.Map<IEnumerable<RoomDto>>(result.Data);

                foreach (var room in roomDto)
                {
                    var featuredDeal = await _mediator.Send(new GetFeaturedDealByRoomIdQuery { RoomId = room.RoomId });

                    room.Discount = featuredDeal.IsSuccess ? featuredDeal.Data.Discount : 0.0;
                }

                string baseUrl = Request.Scheme + "://" + Request.Host + Request.Path;
                string prevPageUrl = page > 1 ? $"{baseUrl}?page={page - 1}&pageSize={pageSize}" : null;
                string nextPageUrl = $"{baseUrl}?page={page + 1}&pageSize={pageSize}";

                var paginationInfo = new
                {
                    PrevPage = prevPageUrl,
                    NextPage = nextPageUrl,
                    count = roomDto.Count()
                };

                var responseObj = new
                {
                    Pagination = paginationInfo,
                    Rooms = roomDto
                };

                return Ok(responseObj);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            

        }

        [HttpPatch("{roomId}")]
        public async Task<ActionResult> UpdateRoom
            (
            Guid roomId,
            JsonPatchDocument<UpdateRoomDto> RoomJsonPatch
            )
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if (userLevel == "2")
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
            else
            {
                return Unauthorized();
            }

        }


        [HttpGet("featuredDeal/{hotelId}")]
        public async Task<ActionResult<IEnumerable<FeaturedDealRoomDto>>> GetRoomsWithFeatureddealsByHotelId(Guid hotelId)
        {

            var result = await _mediator.Send(new GetRoomsWithFeatureddealsByHotelIdQuery { HotelId = hotelId });


            if (result.IsSuccess)
            {
                var roomDto = _mapper.Map<IEnumerable<FeaturedDealRoomDto>>(result.Data);
                foreach (var room in roomDto)
                {
                    var featuredDeal = await _mediator.Send(new GetFeaturedDealsQuery { RoomId = room.RoomId });
                    if (featuredDeal.IsSuccess)
                    {
                        room.Discount = featuredDeal.Data.ToList()[0].Discount;
                    }
                }
                return Ok(roomDto);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

    }
}
