using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IFeaturedDealsRepository
    {
        public Task<FeaturedDeal> AddFeaturedDealAsync(FeaturedDeal featuredDeal);

        public Task<IEnumerable<FeaturedDeal>> GetFeaturedDealsAsync
           (
                Guid? featuredDealId,
                Guid? roomId,
                string? description,
                double? discount,
                DateTime? startDate,
                DateTime? endDate,
                int pageSize,
                int page
           );
        public Task<FeaturedDeal> GetFeaturedDealByRoomIdAsync(Guid roomId);
    }
}
