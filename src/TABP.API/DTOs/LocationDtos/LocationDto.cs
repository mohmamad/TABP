namespace TABP.API.DTOs.LocationDtos
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public Guid CityId { get; set; }
        public List<Link> Links { get; set; }
    }
}
