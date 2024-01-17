using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface ILocationRepository
    {
        public Task<Location> AddHotelLocationAsync(Location location, City city);
    }
}
