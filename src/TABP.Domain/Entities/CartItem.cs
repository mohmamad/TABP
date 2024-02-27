using TABP.Domain.Enums;

namespace TABP.Domain.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public User User { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
