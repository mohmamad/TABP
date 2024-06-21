namespace TABP.API.DTOs.BookingDtos
{
    public class CreateBookingRequestDto
    {
        public string CardDetailsToken { get; set; }
        public string IdempotencyKey { get; set; }
    }
}
