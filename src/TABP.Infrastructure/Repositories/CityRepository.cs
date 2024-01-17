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
    }
}
