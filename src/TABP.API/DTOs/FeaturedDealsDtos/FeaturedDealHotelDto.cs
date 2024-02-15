namespace TABP.API.DTOs.FeaturedDealsDtos
{
    public class FeaturedDealHotelDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public string Amenities { get; set; }
        public string RoomsURL { get; set; }
    }
}
