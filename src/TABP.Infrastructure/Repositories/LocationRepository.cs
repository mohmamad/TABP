using Microsoft.EntityFrameworkCore;
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
            var foundCity = await _dbContext.Cities.FirstOrDefaultAsync(
                c => c.CityName == city.CityName && c.CountryName == city.CountryName);

            if (foundCity != null)
            {
                location.CityId = foundCity.CityId;
            }
            else
            {
                await _dbContext.Cities.AddAsync(city);
                location.CityId = city.CityId;
            }
            
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetLocationByHotelId(Guid hotelId)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(l => l.HotelId == hotelId);
        }

    }
}
