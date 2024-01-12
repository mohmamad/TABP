namespace TABP.Domain.Entities
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public string RoomId { get; set; }
    }
}
