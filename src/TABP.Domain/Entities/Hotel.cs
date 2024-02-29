namespace TABP.Domain.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set;}
        public string HotelDescription { get; set;}
        public double Rating { get; set;}
        public Guid HotelTypeId { get; set; }
        public Location Location { get; set;}
        public List<HotelImage> Images { get; set;}
        public HotelType HotelType { get; set;}
        public List<Room> Rooms { get; set;}
        public List<Review> Reviews { get; set;}
        public List<Amenity> Amenities { get; set;}
    }
}
