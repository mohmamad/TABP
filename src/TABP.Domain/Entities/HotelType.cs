namespace TABP.Domain.Entities
{
    public class HotelType
    {
        public Guid HotelTypeId { get; set; }
        public string Type { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
