namespace TABP.API.DTOs.BookingDtos
{
    public class AddBookingDto
    {
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfResidents { get; set; }
    }
}
