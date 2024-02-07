using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Domain.Entities;

namespace TABP.Application.CQRS.Queries.FeaturedDeals
{
    public class GetFeaturedDealsQuery : IRequest<Result<IEnumerable<FeaturedDeal>>>
    {
        public Guid? FeaturedDealId;
        public Guid? RoomId;
        public string? Description;
        public double? Discount;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public int PageSize = 30;
        public int Page = 1;
    }
}
