namespace TABP.Domain.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set;}
        public string HotelDescription { get; set;}
        public Guid LocationId { get; set; }
    }
}
