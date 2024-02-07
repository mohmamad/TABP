using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.FeaturedDeals;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.FeaturedDealHandlers
{
    public class GetFeaturedDealsQueryHandler : IRequestHandler<GetFeaturedDealsQuery, Result<IEnumerable<FeaturedDeal>>>
    {
        private readonly IFeaturedDealsRepository _featuredDealsRepository;
        public GetFeaturedDealsQueryHandler(IFeaturedDealsRepository featuredDealsRepository)
        {
            _featuredDealsRepository = featuredDealsRepository;
        }

        public async Task<Result<IEnumerable<FeaturedDeal>>> Handle(GetFeaturedDealsQuery request, CancellationToken cancellationToken)
        {
            var featuredDeals = await _featuredDealsRepository.GetFeaturedDealsAsync
                (
                    request.FeaturedDealId,
                    request.RoomId,
                    request.Description,
                    request.Discount,
                    request.StartDate,
                    request.EndDate,
                    request.PageSize,
                    request.Page
                );
            if(featuredDeals != null)
            {
                return Result<IEnumerable<FeaturedDeal>>.Success(featuredDeals);
            }
            else
            {
                return Result<IEnumerable<FeaturedDeal>>.Failure("Featured Deal Not Found.");
            }
        }
    }
}
