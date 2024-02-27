using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.API.DTOs.CardItemDtos;
using TABP.API.DTOs.CartItemDtos;
using TABP.Application.CQRS.Commands.CartItemCommands;
using TABP.Application.CQRS.Queries.CartItemQueries;
using TABP.Application.CQRS.Queries.FeaturedDeals;
using TABP.Application.CQRS.Queries.RoomQueries;

namespace TABP.API.Controllers
{
    [ApiController]
    [Route("api/user/{userId}/Cart")]
    public class CartItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CartItemController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(AddCardItemDto addCardItemDto, Guid userId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"));
            var userIdFromToken = new Guid();
            if (userIdClaim != null)
            {
                userIdFromToken = Guid.Parse(userIdClaim.Value);
            }
            else
            {
                return Unauthorized();
            }
            if (userIdFromToken == userId)
            {
                var result = await _mediator.Send(
                     new AddToCartCommand
                     {
                         UserId = userId,
                         RoomId = addCardItemDto.RoomId,
                         StartDate = addCardItemDto.StartDate,
                         EndDate = addCardItemDto.EndDate,
                         NumberOfResidents = addCardItemDto.NumberOfResidents
                     });
                if (result.IsSuccess)
                {
                    return Ok();
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
        public async Task<ActionResult<CartItemDto>> GetCartItemsByUserId(Guid userId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"));
            var userIdFromToken = new Guid();
            if (userIdClaim != null)
            {
                userIdFromToken = Guid.Parse(userIdClaim.Value);
            }
            else
            {
                return Unauthorized();
            }

            if (userIdFromToken == userId)
            {
                var result = await _mediator.Send(new GetCartItemByUserIdQurey
                {
                    UserId = userId
                });

                if (result.IsSuccess)
                {
                    var dtoToReturn = _mapper.Map<IEnumerable<CartItemDto>>(result.Data);
                    foreach (var cartItem in dtoToReturn)
                    {
                        var room = await _mediator.Send(new GetRoomByIdQuery { RoomId = cartItem.RoomId });
                        var featuredDeal = await _mediator.Send(new GetFeaturedDealByRoomIdQuery { RoomId = cartItem.RoomId });
                        cartItem.Price = room.Data.Price;
                        if (featuredDeal.IsSuccess)
                        {
                            cartItem.Discount = featuredDeal.Data.Discount;
                        }
                    }

                    return Ok(dtoToReturn);
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

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> DeleteCartItem(Guid cartItemId, Guid userId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"));
            var userIdFromToken = new Guid();
            if (userIdClaim != null)
            {
                userIdFromToken = Guid.Parse(userIdClaim.Value);
            }
            else
            {
                return Unauthorized();
            }

            if (userIdFromToken == userId)
            {
                var result = await _mediator.Send(new DeleteCartItemCommand
                {
                    CartItemdId = cartItemId,
                    UserId = userId
                });

                if (result.IsSuccess)
                {

                    return NoContent();
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


    }
}
