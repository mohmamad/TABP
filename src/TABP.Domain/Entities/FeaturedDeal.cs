namespace TABP.Domain.Entities
{
    public class FeaturedDeal
    {
        public Guid FeaturedDealId { get; set; }
        public Guid RoomId { get; set;}
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
    }
}
