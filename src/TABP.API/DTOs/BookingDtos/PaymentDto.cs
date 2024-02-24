namespace TABP.API.DTOs.BookingDtos
{
    public class PaymentDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<Link> Links { get; set; }   
    }
}
