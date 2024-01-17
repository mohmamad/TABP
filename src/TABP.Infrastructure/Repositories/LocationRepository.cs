using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TABPDbContext _dbContext;
        public LocationRepository(TABPDbContext TABPDbContext)
        {
            _dbContext = TABPDbContext;
        }
        public async Task<Location> AddHotelLocationAsync(Location location, City city)
        {
            await _dbContext.Cities.AddAsync(city);
            location.CityId = city.CityId;
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }
    }
}
