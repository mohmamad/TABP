using Microsoft.AspNetCore.Routing.Constraints;

namespace TABP.API.DTOs.RoomDtos
{
    public class RoomDto
    {
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Capacity { get; set; }
        public List<Link> Links { get; set; }
    }
}
