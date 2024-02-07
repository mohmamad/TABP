using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class HotelTypeRepository : IHotelTypeRepository
    {
        private readonly TABPDbContext _dbContext;
        public HotelTypeRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<HotelType> AddHotelTypeAsync(HotelType hotelType)
        {
            await _dbContext.AddAsync(hotelType);
            await _dbContext.SaveChangesAsync();
            return hotelType;
        }

        public async Task<HotelType> GetHotelTypeById(Guid hotelTypeId)
        {
            return await _dbContext.HotelTypes.FirstOrDefaultAsync(h => h.HotelTypeId == hotelTypeId);
        }
    }
}
