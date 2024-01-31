namespace TABP.Domain.Entities
{
    public class HotelImage
    {
        public Guid HotelImageId { get; set; }
        public string ImagePath { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
