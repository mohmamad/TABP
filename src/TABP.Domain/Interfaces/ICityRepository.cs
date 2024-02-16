using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface ICityRepository
    {
        public Task<City> GetCityAsync(Guid CityId);
        public Task<IEnumerable<City>> GetMostVistedCitiesAsync();
    }
}
