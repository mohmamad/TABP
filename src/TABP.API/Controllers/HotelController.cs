using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.HotelDtos;
using TABP.API.DTOs.LocationDtos;
using TABP.Application.CQRS.Commands.HotelCommands;
using TABP.Application.CQRS.Commands.LocationCommands;
using TABP.Application.CQRS.Queries.HotelQueries;

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
        public async Task<ActionResult<HotelTypeDto>> AddHotelType(AddHotelTypeDto addHotelTypeDto)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddHotelTypeCommand
                {
                    HotelType = addHotelTypeDto.HotelType
                });
                var dtoToReturn = _mapper.Map<HotelTypeDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoundHotelDto>>> GetHotel
            (
                [FromQuery] Guid? hotelId,
                [FromQuery] string? hotelName,
                [FromQuery] string? hotelDescription,
                [FromQuery] double? rating,
                [FromQuery] string? amenities,
                [FromQuery] Guid? hotelTypeId,
                [FromQuery] string? hotelType,
                [FromQuery] double? minPrice,
                [FromQuery] double? maxPrice,
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
                HotelType = hotelType,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                PageSize = pageSize,
                Page = page
            });
            if (result.IsSuccess)
            {
                var hotelDto = _mapper.Map<IEnumerable<FoundHotelDto>>(result.Data);
                foreach(var hotel in hotelDto)
                {
                    hotel.RoomsURL = $"/api/room?hotelId={hotel.HotelId}&minPrice={minPrice}&maxPrice={maxPrice}";
                }
                return Ok(hotelDto);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }

        [HttpPatch("{hotelId}")]
        public async Task<ActionResult> UpdateHotel
            (
            Guid hotelId,
            JsonPatchDocument<UpdateHotelDto> hotelJsonPatch
            )
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;
            if (userLevel == "2")
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

        [HttpGet("hotelType/{hotelTypeId}")]
        public async Task<ActionResult<HotelTypeDto>> GetHotelTypeById(Guid hotelTypeId)
        {
            var result = await _mediator.Send(new GetHotelTypeByIdQuery
            {
                hotelTypeId = hotelTypeId
            });
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<HotelTypeDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }
        [HttpPost("hotelImage/{hotelId}")]
        public async Task<ActionResult<HotelImageDto>> AddHotelImage([FromForm] AddHotelImageDto imageFile, Guid hotelId)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.HotelImage.FileName);

                var filePath = await _mediator.Send(new SaveImageCommand
                {
                    CityImage = imageFile.HotelImage,
                    FileName = fileName,
                });
                var result = await _mediator.Send(new AddHotelImageCommand
                {
                    HotelId = hotelId,
                    HotelImagePath = filePath.Data
                });
                var dtoToReturn = _mapper.Map<HotelImageDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return Unauthorized();
            }
                
        }

        [HttpGet("hotelImage/{hotelId}")]
        public async Task<ActionResult<HotelImageDto>> GetHotelImageByHotelId(Guid hotelId)
        {
            var result = await _mediator.Send(new GetHotelImageByHotelIdQuery
            {
                HotelId = hotelId
            });
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<HotelImageDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }

    }
}
