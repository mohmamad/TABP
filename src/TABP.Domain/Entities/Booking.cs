namespace TABP.Domain.Entities
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
