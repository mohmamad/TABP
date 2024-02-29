using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IAmenityRepository
    {
        public Task<Amenity> AddAmenityAsync(Amenity amenity);
        public Task<IEnumerable<Amenity>> GetAmenityByHotelIdAsync(Guid HotelId);
    }
}
