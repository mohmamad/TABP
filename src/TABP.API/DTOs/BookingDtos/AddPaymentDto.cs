namespace TABP.API.DTOs.BookingDtos
{
    public class AddPaymentDto
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardId { get; set; }
        public double Price { get; set; }
    }
}
