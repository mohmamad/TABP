namespace TABP.API.DTOs.LocationDtos
{
    public class AddLocationDto
    {
        public string CountryName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public IFormFile CityImage { get; set; }

    }
}
