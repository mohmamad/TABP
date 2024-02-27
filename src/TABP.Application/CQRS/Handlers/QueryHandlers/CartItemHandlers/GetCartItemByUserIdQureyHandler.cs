using MediatR;
using Microsoft.IdentityModel.Tokens;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.CartItemQueries;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.CartItemHandlers
{
    public class GetCartItemByUserIdQureyHandler : IRequestHandler<GetCartItemByUserIdQurey, Result<IEnumerable<CartItem>>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetCartItemByUserIdQureyHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result<IEnumerable<CartItem>>> Handle(GetCartItemByUserIdQurey request, CancellationToken cancellationToken)
        {
            var cartItems = await _cartItemRepository.GetCartItemsByUserIdAsync(request.UserId);
            return Result<IEnumerable<CartItem>>.Success(cartItems);
        }
    }
}
