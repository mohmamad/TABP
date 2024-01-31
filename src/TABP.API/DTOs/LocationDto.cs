namespace TABP.API.DTOs
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public Guid CityId { get; set; }
        public string CityURL { get; set; }
    }
}
