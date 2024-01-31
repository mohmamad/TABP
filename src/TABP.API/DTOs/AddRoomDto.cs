namespace TABP.API.DTOs
{
    public class AddRoomDto
    {
        public Guid RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
