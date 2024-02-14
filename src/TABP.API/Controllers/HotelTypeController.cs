using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.HotelDtos;
using TABP.Application.CQRS.Commands.HotelCommands;
using TABP.Application.CQRS.Queries.HotelQueries;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/hotelType")]
    public class HotelTypeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HotelTypeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
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

        [HttpGet("{hotelTypeId}")]
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

    }
}
