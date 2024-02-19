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
            var mostVisitedCities = (from booking in _dbContext.Bookings
                                         join room in _dbContext.Rooms on booking.RoomId equals room.RoomId
                                         join hotel in _dbContext.Hotels on room.HotelId equals hotel.HotelId
                                         join location in _dbContext.Locations on hotel.HotelId equals location.HotelId
                                         join city in _dbContext.Cities on location.CityId equals city.CityId
                                         group city by city into g
                                         orderby g.Count() descending
                                         select g.Key)
                                        .Take(5)
                                        .ToList();
            return mostVisitedCities;
        }
    }
}
