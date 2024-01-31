namespace TABP.API.DTOs
{
    public class AddHotelDto
    {
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public string Amenities { get; set; }
        public Guid HotelTypeId { get; set; }
    }
}
