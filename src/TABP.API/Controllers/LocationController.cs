using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs;
using TABP.Application.CQRS.Commands;
using TABP.Application.CQRS.Queries;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LocationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AddLocationDto>> Upload([FromForm] AddLocationDto imageFile)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                if (imageFile.CityImage != null && imageFile.CityImage.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.CityImage.FileName);

                    var filePath = Path.Combine("C:\\Users\\GoldenTech\\Desktop\\study\\intern\\project\\TravelandAccommodationBookingPlatform\\src\\TABP.Infrastructure\\images\\", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CityImage.CopyTo(stream);
                    }
                    var result = await _mediator.Send(new AddHotelLocationCommand
                    {
                        CountryName = imageFile.CountryName,
                        StreetName = imageFile.StreetName,
                        CityName = imageFile.CityName,
                        CityDescription = imageFile.CityDescription,
                        PostalCode = imageFile.PostalCode,
                        ImagePath = filePath,
                    });

                    var location = _mapper.Map<LocationDto>(result.Data);

                    return Ok(location);
                }
                return BadRequest();
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet("city/{CityId}")]

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
    }
}
