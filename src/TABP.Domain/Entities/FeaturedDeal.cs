namespace TABP.Domain.Entities
{
    public class FeaturedDeal
    {
        public Guid DealId { get; set; }
        public Guid HotelId { get; set;}
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
