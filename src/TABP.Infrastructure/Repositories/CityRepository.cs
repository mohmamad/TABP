using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly TABPDbContext _dbContext;
        public CityRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> GetCityAsync(Guid CityId)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(c => c.CityId == CityId);
            await _dbContext.SaveChangesAsync();
            return city;
        } 

        public async Task<IEnumerable<City>> GetMostVistedCitiesAsync()
        {
            var mostBookedHotels = _dbContext.Bookings
            .Include(b => b.Room.Hotel.Location)
            .Include(b => b.Room.Hotel.Location.City)
            .GroupBy(b => b.Room.Hotel)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();
            List<Location> locations = new List<Location>();
            foreach (var hotel in mostBookedHotels)
            {
                var location = _dbContext.Locations.Include(l => l.City).FirstOrDefault(l => l.HotelId == hotel.HotelId);
                locations.Add(location);
            }
            //var locationOfMostBookedHotels = mostBookedHotels
            //.Select(h => h.Location) // Navigate to the location from the hotel
            //.Distinct() // Ensure unique locations
            //.ToList();

            return locations.Select(l => l.City).ToList();
        }
    }
}
