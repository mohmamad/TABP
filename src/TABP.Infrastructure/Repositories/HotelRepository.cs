using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TABPDbContext _dbContext;
        public HotelRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hotel> AddHotelAsync(Hotel hotel)
        {

            await _dbContext.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;


        }

        public async Task<HotelType> GetHotelTypeByIdAsync(Guid TypeId)
        {
            return await _dbContext.HotelTypes.FirstOrDefaultAsync(h => h.HotelTypeId == TypeId);
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync
            (
                 Guid? hotelId,
                 string? hotelName,
                 string? hotelDescription,
                 double? rating,
                 string? amenities,
                 Guid? hotelTypeId,
                 int pageSize,
                 int page
            )
        {
            IQueryable<Hotel> hotelQuery = _dbContext.Hotels;

            if (hotelId != null)
            {
                hotelQuery = hotelQuery.Where(h => h.HotelId == hotelId);
            }
            if (hotelName != null)
            {
                hotelQuery = hotelQuery.Where(h => h.HotelName == hotelName);
            }
            if (hotelDescription != null)
            {
                hotelQuery = hotelQuery.Where(h => h.HotelDescription == hotelDescription);
            }
            if (rating != null)
            {
                hotelQuery = hotelQuery.Where(h => h.Rating == rating);
            }
            if (amenities != null)
            {
                hotelQuery = hotelQuery.Where(h => h.Amenities == amenities);
            }
            if (hotelTypeId != null)
            {
                hotelQuery = hotelQuery.Where(h => h.HotelTypeId == hotelTypeId);
            }

            return await hotelQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Hotel> GetHotelById(Guid hotelId)
        {
            return await _dbContext.Hotels.FirstOrDefaultAsync(h => h.HotelId == hotelId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<HotelImage> AddHotelImageAsync(HotelImage hotelImage)
        {
            await _dbContext.AddAsync(hotelImage);
            await _dbContext.SaveChangesAsync();
            return hotelImage;
        }

        public async Task<HotelImage> GetHotelImageByHotelIdAsync(Guid hotelId)
        {
            return await _dbContext.HotelImages.FirstOrDefaultAsync(h => h.HotelId == hotelId);
        }
    }
}
