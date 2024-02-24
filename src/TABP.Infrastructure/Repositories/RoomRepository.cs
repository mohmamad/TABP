using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly TABPDbContext _dbContext;
        public RoomRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            room.IsAvaiable = true;
            await _dbContext.AddAsync(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync
            (
                Guid? roomId,
                Guid? hotelId,
                Guid? roomTypeId,
                int? roomNumber,
                double? price,
                int? capacity,
                double? maxPrice,
                double? minPrice,
                DateTime? startDate,
                DateTime? endDate,
                int pageSize,
                int page
            )
        {
            IQueryable<Room> roomQuery = _dbContext.Rooms;

            if (roomId != null)
            {
                roomQuery = roomQuery.Where(r => r.RoomId == roomId);
            }
            if (hotelId != null)
            {
                roomQuery = roomQuery.Where(r => r.HotelId == hotelId);
            }
            if (roomTypeId != null)
            {
                roomQuery = roomQuery.Where(r => r.RoomTypeId == roomTypeId);
            }
            if (roomNumber != null)
            {
                roomQuery = roomQuery.Where(r => r.RoomNumber == roomNumber);
            }
            if (price != null)
            {
                roomQuery = roomQuery.Where(r => r.Price == price);
            }
            if (capacity != null)
            {
                roomQuery = roomQuery.Where(r => r.Capacity == capacity);
            }
            if (maxPrice != null)
            {
                roomQuery = roomQuery.Where(r => r.Price <= maxPrice);
            }
            if (minPrice != null)
            {
                roomQuery = roomQuery.Where(r => r.Price >= minPrice);
            }
            if (startDate != null && endDate != null)
            {
                roomQuery = roomQuery.Where(r => r.Bookings.Any(b => !(b.StartDate >= startDate && b.StartDate <= endDate || b.EndDate >= startDate && b.EndDate <= endDate)));
            }

            return await roomQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<RoomType> AddRoomTypeAsync(RoomType roomType)
        {
            await _dbContext.AddAsync(roomType);
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task<Room> GetRoomByIdAsync(Guid roomId)
        {
            return await _dbContext.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
        }

        public async Task<RoomType> GetRoomTypeByRoomIdAsync(Guid roomTypeId)
        {
            return await _dbContext.RoomTypes.FirstOrDefaultAsync(r => r.RoomTypeId == roomTypeId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Room>> GetRoomsWithFeaturedDealsByHotelIdAsync(Guid hotelId)
        {
            var rooms = _dbContext.Rooms.Where(r => r.FeaturedDeals.Any(f => f.EndDate > DateTime.UtcNow));
            return rooms;
        }
    }
}
