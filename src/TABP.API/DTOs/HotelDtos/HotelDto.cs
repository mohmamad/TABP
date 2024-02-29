namespace TABP.API.DTOs.HotelDtos
{
    public class HotelDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public List<Link> Links { get; set; }
    }
}
