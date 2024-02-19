using MediatR;
using TABP.API.CQRS.Handlers;
using TABP.Application.CQRS.Queries.FeaturedDeals;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Application.CQRS.Handlers.QueryHandlers.FeaturedDealHandlers
{
    class GetFeaturedDealByRoomIdQueryHandler : IRequestHandler<GetFeaturedDealByRoomIdQuery, Result<FeaturedDeal>>
    {
        private readonly IFeaturedDealsRepository _featuredDealsRepository;
        public GetFeaturedDealByRoomIdQueryHandler(IFeaturedDealsRepository featuredDealsRepository)
        {
            _featuredDealsRepository = featuredDealsRepository;
        }

        public async Task<Result<FeaturedDeal>> Handle(GetFeaturedDealByRoomIdQuery request, CancellationToken cancellationToken)
        {
            var featuredDeal = await _featuredDealsRepository.GetFeaturedDealByRoomIdAsync(request.RoomId);
            if(featuredDeal != null)
            {
                return Result<FeaturedDeal>.Success(featuredDeal);
            }
            else
            {
                return Result<FeaturedDeal>.Failure("Featured Deal Not Found.");
            }
        }
    }
}
