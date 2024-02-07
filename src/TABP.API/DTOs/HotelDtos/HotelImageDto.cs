namespace TABP.API.DTOs.HotelDtos
{
    public class HotelImageDto
    {
        public Guid HotelImageId { get; set; }
        public string ImagePath { get; set; }
        public Guid HotelId { get; set; }
    }
}
