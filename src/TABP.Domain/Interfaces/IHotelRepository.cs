using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IHotelRepository
    {
        public Task<Hotel> AddHotelAsync(Hotel hotel);
        public Task<HotelType> GetHotelTypeByIdAsync(Guid TypeId);
        public Task<IEnumerable<Hotel>> GetHotelsAsync
           (
                Guid? hotelId,
                string? hotelName,
                string? hotelDescription,
                double? rating,
                string? amenities,
                Guid? hotelTypeId,
                string? hotelType,
                double? minPrice,
                double? maxPrice,
                DateTime? startDate,
                DateTime? endDate,
                string? city,
                int? numberOfRooms,
                int pageSize = 30,
                int page = 1
           );
        public Task<bool> SaveChangesAsync();
        public Task<Hotel> GetHotelById(Guid hotelId);
        public Task<HotelImage> AddHotelImageAsync(HotelImage hotelImage);
        public Task<HotelImage> GetHotelImageByHotelIdAsync(Guid hotelId);
        public Task<IEnumerable<Hotel>> GetHotelWithFeaturedDeals();
        public Task<IEnumerable<Hotel>> GetLatestVisitedHotelForUser(Guid userId);
    }
}
