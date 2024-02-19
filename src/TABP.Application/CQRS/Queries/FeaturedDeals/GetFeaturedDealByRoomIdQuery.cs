using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.FeaturedDeals
{
    public class GetFeaturedDealByRoomIdQuery : IRequest<Result<FeaturedDeal>>
    {
        public Guid RoomId { get; set; }
    }
}
