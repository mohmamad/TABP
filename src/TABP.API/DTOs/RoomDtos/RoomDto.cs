namespace TABP.API.DTOs.RoomDtos
{
    public class RoomDto
    {
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string BookingURL { get; set; }
        public string HotelURL { get; set; }
        public string RoomTypeURL { get; set; }
    }
}
