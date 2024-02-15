using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.FeaturedDealsDtos;
using TABP.Application.CQRS.Commands.FeaturedDealsCommands;
using TABP.Application.CQRS.Queries.FeaturedDeals;
using TABP.Domain.Entities;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/room/FeaturedDeal")]
    public class FeaturedDealsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FeaturedDealsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("{roomId}")]
        public async Task<ActionResult<FeaturedDealsDto>> AddFeaturedDeal(FeaturedDealsAddDto featuredDealsAddDto, Guid roomId)
        {
            var userLevel = User.Claims.FirstOrDefault(r => r.Type.EndsWith("role"))?.Value;

            if (userLevel == "2")
            {
                var result = await _mediator.Send(new AddFeaturedDealCommand
                {
                    RoomId = roomId,
                    Description = featuredDealsAddDto.Description,
                    Discount = featuredDealsAddDto.Discount,
                    StartDate = featuredDealsAddDto.StartDate,
                    EndDate = featuredDealsAddDto.EndDate,
                });
                if (result.IsSuccess)
                {
                    var featuredDealDto = _mapper.Map<FeaturedDealsDto>(result.Data);
                    return Ok(featuredDealDto);
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
        public async Task<ActionResult<IEnumerable<FeaturedDealsDto>>> GetFeaturedDeals
            (
                [FromQuery] Guid? featuredDealId,
                [FromQuery] Guid? roomId,
                [FromQuery] string? description,
                [FromQuery] double? discount,
                [FromQuery] DateTime? startDate,
                [FromQuery] DateTime? endDate,
                [FromQuery] int pageSize = 30,
                [FromQuery] int page = 1
            )
        {
            var result = await _mediator.Send
                (
                new GetFeaturedDealsQuery
                {
                    FeaturedDealId = featuredDealId,
                    RoomId = roomId,
                    Description = description,
                    Discount = discount,
                    StartDate = startDate,
                    EndDate = endDate,
                    PageSize = pageSize,
                    Page = page
                });

            if (result.IsSuccess)
            {
                var DtoToReturn = _mapper.Map<IEnumerable<FeaturedDeal>>(result.Data);
                return Ok(DtoToReturn);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
            
        }


    }
}
