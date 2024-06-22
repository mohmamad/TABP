using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IHotelTypeRepository
    {
        public Task<HotelType> AddHotelTypeAsync(HotelType hotelType);
        public Task<HotelType> GetHotelTypeById(Guid hotelTypeId);
        public Task<HotelType> GetHotelTypeByHotelId(Guid hotelId);
        public Task<List<HotelType>> GetHotelTypesAsync();
    }
}
