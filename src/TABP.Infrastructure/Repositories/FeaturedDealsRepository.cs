using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class FeaturedDealsRepository : IFeaturedDealsRepository
    {
        private readonly TABPDbContext _dbContext;
        public FeaturedDealsRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FeaturedDeal> AddFeaturedDealAsync(FeaturedDeal featuredDeal)
        {
            await _dbContext.AddAsync(featuredDeal);
            await _dbContext.SaveChangesAsync();
            return featuredDeal;
        }

        public async Task<IEnumerable<FeaturedDeal>> GetFeaturedDealsAsync
            (
                 Guid? featuredDealId,
                 Guid? roomId,
                 string? description,
                 double? discount,
                 DateTime? startDate,
                 DateTime? endDate,
                 int pageSize,
                 int page
            )
        {
            IQueryable<FeaturedDeal> featuredDealQuery = _dbContext.FeaturedDeals;

            if (featuredDealId != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.FeaturedDealId == featuredDealId && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }
            if (roomId != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.RoomId == roomId && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }
            if (description != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.Description == description && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }
            if (discount != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.Discount == discount && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }
            if (startDate != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.StartDate == startDate && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }
            if (endDate != null)
            {
                featuredDealQuery = featuredDealQuery.Where(f => f.EndDate == endDate && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
            }

            return await featuredDealQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<FeaturedDeal> GetFeaturedDealByRoomIdAsync(Guid roomId)
        {
            return await _dbContext.FeaturedDeals.FirstOrDefaultAsync(f => f.RoomId == roomId && f.StartDate <= DateTime.UtcNow && f.EndDate >= DateTime.UtcNow);
        }
    }
}
