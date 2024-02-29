using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly TABPDbContext _dbContext;
        public AmenityRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Amenity> AddAmenityAsync(Amenity amenity)
        {
            await _dbContext.AddAsync(amenity);
            await _dbContext.SaveChangesAsync();

            return amenity;
        }

        public async Task<IEnumerable<Amenity>> GetAmenityByHotelIdAsync(Guid HotelId)
        {
            var Amenities = await _dbContext.Amenities.Where(a => a.HotelId == HotelId).ToListAsync();
            return Amenities;
        }

    }
}
