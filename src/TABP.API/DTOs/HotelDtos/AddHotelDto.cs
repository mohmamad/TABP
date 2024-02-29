namespace TABP.API.DTOs.HotelDtos
{
    public class AddHotelDto
    {
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public Guid HotelTypeId { get; set; }
    }
}
