namespace TABP.Domain.Entities
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }
    }
}

