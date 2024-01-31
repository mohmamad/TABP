using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IRoomRepository
    {
        public Task<Room> AddRoomAsync(Room room);

        public Task<IEnumerable<Room>> GetRoomsAsync
           (
               Guid? roomId,
               Guid? hotelId,
               Guid? roomTypeId,
               int? roomNumber,
               double? price,
               int? capacity,
               bool? isAvaiable,
               int pageSize = 30,
               int page = 1
           );

        public Task<RoomType> AddRoomTypeAsync(RoomType roomType);
        public Task<RoomType> GetRoomTypeByRoomIdAsync(Guid roomTypeId);
        public Task<Room> GetRoomByIdAsync(Guid roomId);
        public Task<bool> SaveChangesAsync();
    }
}
