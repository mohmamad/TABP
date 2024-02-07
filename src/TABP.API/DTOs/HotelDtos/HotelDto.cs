namespace TABP.API.DTOs.HotelDtos
{
    public class HotelDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public double Rating { get; set; }
        public string Amenities { get; set; }
        public string HotelTypeURL { get; set; }
        public string HotelLocationURL { get; set; }
        public string RoomsURL { get; set; }
        public string AddLocationURL { get; set; }
        public string AddHotelImageURL { get; set; }
        public string HotelImageURL { get; set; }
        public string BookingURL { get; set; }

    }
}
