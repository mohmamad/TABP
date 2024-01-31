namespace TABP.Domain.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public Guid RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public bool IsAvaiable { get; set; }    
        public List<Booking> Bookings { get; set; }
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
    }
}
