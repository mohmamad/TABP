using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.AmenityDtos;
using TABP.Application.CQRS.Commands.AmenityCommands;
using TABP.Application.CQRS.Queries.AmenityQueries;
using TABP.Domain.Entities;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/hotel/{hotelId}/amenities")]
    public class AmenityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AmenityController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AmenityDto>> AddAmenity(AddAmenityDto addAmenityDto, Guid hotelId)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddAmenityCommand
                {
                    HotleId = hotelId,
                    Name = addAmenityDto.Name,
                    Description = addAmenityDto.Description
                });

                var dtoToReturn = _mapper.Map<AmenityDto>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDto>>> GetAmenities(Guid hotelId)
        {
            var result = await _mediator.Send(new GetAmenityByHotelIdQuery { HotelId = hotelId});
            if (result.IsSuccess)
            {
                var dtoToReturn = _mapper.Map<IEnumerable<AmenityDto>>(result.Data);
                return Ok(dtoToReturn);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
            
        }
    }
}
