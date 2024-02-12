namespace TABP.API.DTOs.BookingDtos
{
    public class PaymentDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string RoomURL { get; set; }
        public string PaymentURL { get; set; }
    }
}
