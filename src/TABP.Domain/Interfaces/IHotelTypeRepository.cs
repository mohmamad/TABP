using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IHotelTypeRepository
    {
        public Task<HotelType> AddHotelTypeAsync(HotelType hotelType);
    }
}
