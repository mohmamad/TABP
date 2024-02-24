using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.LocationDtos;
using TABP.Application.CQRS.Commands.LocationCommands;
using TABP.Application.CQRS.Queries.LocationQueries;

namespace TABP.API.Controllers
{

    [ApiController]
    [Route("api/hotel")]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LocationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("{hotelId}/location")]
        [Authorize]
        public async Task<ActionResult<AddLocationDto>> AddLocation([FromForm] AddLocationDto imageFile, Guid hotelId)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                if (imageFile.CityImage != null && imageFile.CityImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.CityImage.FileName);

                    var filePath = await _mediator.Send(new SaveImageCommand
                    {
                        CityImage = imageFile.CityImage,
                        FileName = fileName,
                    });

                    var result = await _mediator.Send(new AddHotelLocationCommand
                    {
                        CountryName = imageFile.CountryName,
                        StreetName = imageFile.StreetName,
                        CityName = imageFile.CityName,
                        CityDescription = imageFile.CityDescription,
                        PostalCode = imageFile.PostalCode,
                        ImagePath = filePath.Data,
                        HotelId = hotelId,
                    });
                    if (result.IsSuccess)
                    {
                        var location = _mapper.Map<LocationDto>(result.Data);

                        return Ok(location);
                    }
                    else
                    {
                        return BadRequest(result.ErrorMessage);
                    }
                }
                return BadRequest();
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet("location/city/{CityId}")]

        public async Task<ActionResult<CityDto>> GetCity(Guid CityId)
        {
            var result = await _mediator.Send(new GetCityQuery
            {
                CityId = CityId
            });

            var city = _mapper.Map<CityDto>(result.Data);
            if (result.IsSuccess)
            {
                return Ok(city);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpGet("{hotelId}/location")]
        public async Task<ActionResult<LocationDto>> GetLocationByHotelId(Guid hotelId)
        {
            var result = await _mediator.Send(new GetLocationByHotelIdQuery
            {
                HotelId = hotelId
            });
            if (result.IsSuccess)
            {
                var DtoToReturn = _mapper.Map<LocationDto>(result.Data);
                return Ok(DtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet("/api/location/cities/mostVisited")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetMostVisitedCities()
        {
            var result = await _mediator.Send(new GetMostVisitedCitiesQuery());
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<IEnumerable<CityDto>>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }
    }
}
