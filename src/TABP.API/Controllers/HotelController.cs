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
    [Route("api/hotel")]
    public class HotelController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HotelController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<HotelDto>> AddHotel(AddHotelDto addHotelDto)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddHotelCommand
                {
                    HotelDescription = addHotelDto.HotelDescription,
                    HotelName = addHotelDto.HotelName,
                    Amenities = addHotelDto.Amenities,
                    Rating = addHotelDto.Rating,
                    HotelTypeId = addHotelDto.HotelTypeId
                });
                if (result.IsSuccess)
                {
                    var hotelDto = _mapper.Map<HotelDto>(result.Data);
                    return Ok(hotelDto);
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

        [HttpPost("hotelType")]
        public async Task<ActionResult<HotelType>> AddHotelType(AddHotelTypeDto addHotelTypeDto)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddHotelTypeCommand
                {
                    HotelType = addHotelTypeDto.HotelType
                });

                return Ok(result.Data);
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotel
            (
                [FromQuery] Guid? hotelId,
                [FromQuery] string? hotelName,
                [FromQuery] string? hotelDescription,
                [FromQuery] double? rating,
                [FromQuery] string? amenities,
                [FromQuery] Guid? hotelTypeId,
                [FromQuery] int pageSize = 30,
                [FromQuery] int page = 1
            )
        {
            var result = await _mediator.Send(new GetHotelsQuery
            {
                HotelId = hotelId,
                HotelName = hotelName,
                HotelDescription = hotelDescription,
                Rating = rating,
                Amenities = amenities,
                HotelTypeId = hotelTypeId,
                PageSize = pageSize,
                Page = page
            });

            var hotelDto = _mapper.Map<IEnumerable<HotelDto>>(result.Data);
            return Ok(hotelDto);
        }

        [HttpPatch("{hotelId}")]
        public async Task<ActionResult> UpdateHotel
            (
            Guid hotelId, 
            JsonPatchDocument<UpdateHotelDto> hotelJsonPatch
            )
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if ( userLevel == "2" )
            {
                var result = await _mediator.Send(new GetHotelByIdQuery
                {
                    HotelId = hotelId
                });

                if (!result.IsSuccess)
                {
                    return NotFound();
                }
                var hotel = result.Data;
                var hotelDtoForUpdate = _mapper.Map<UpdateHotelDto>(hotel);
                hotelJsonPatch.ApplyTo(hotelDtoForUpdate, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!TryValidateModel(hotelDtoForUpdate))
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(hotelDtoForUpdate, hotel);

                await _mediator.Send(new SaveHotelChangesCommand());

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
            
        }


    }
}
