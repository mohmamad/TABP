using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Commands.CartItemCommands;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.CommandHandlers.CartItemHandlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Result<bool>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result<bool>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _cartItemRepository.DeleteCartItemAsync(request.CartItemdId, request.UserId);
            if (isDeleted)
            {
                return Result<bool>.Success();
            }
            else
            {
                return Result<bool>.Failure("CartItem not found.");
            }
                
            
        }
    }
}
