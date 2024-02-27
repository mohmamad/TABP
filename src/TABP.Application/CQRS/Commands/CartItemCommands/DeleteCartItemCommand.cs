using MediatR;
using TABP.API.CQRS.Handlers;

namespace TABP.Application.CQRS.Commands.CartItemCommands
{
    public class DeleteCartItemCommand : IRequest<Result<bool>>
    {
        public Guid CartItemdId { get; set; }
        public Guid UserId { get; set; }
    }
}
