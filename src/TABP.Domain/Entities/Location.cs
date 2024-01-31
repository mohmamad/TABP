namespace TABP.Domain.Entities
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public Guid CityId { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public City City { get; set; }
    }
}
