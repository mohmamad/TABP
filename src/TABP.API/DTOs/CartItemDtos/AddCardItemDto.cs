namespace TABP.API.DTOs.CardItemDtos
{
    public class AddCardItemDto
    {
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfResidents { get; set; }
    }
}
