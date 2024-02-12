namespace TABP.API.DTOs.BookingDtos
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomURL { get; set; }
        public string UserURL { get; set; }
    }
}
