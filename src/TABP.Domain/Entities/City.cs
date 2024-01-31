namespace TABP.Domain.Entities
{
    public class City
    {
        public Guid CityId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public string CityImagePath { get; set; }
        List<Location> locations { get; set; }
    }
}
