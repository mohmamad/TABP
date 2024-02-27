using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.CartItemQueries
{
    public class GetCartItemByUserIdQurey : IRequest<Result<IEnumerable<CartItem>>>
    {
        public Guid UserId { get; set; }
    }
}
