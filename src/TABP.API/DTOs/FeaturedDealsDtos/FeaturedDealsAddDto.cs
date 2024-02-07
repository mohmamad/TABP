namespace TABP.API.DTOs.FeaturedDealsDtos
{
    public class FeaturedDealsAddDto
    {
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
