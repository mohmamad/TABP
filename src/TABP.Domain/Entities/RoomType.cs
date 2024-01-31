namespace TABP.Domain.Entities
{
    public class RoomType
    {
        public Guid RoomTypeId { get; set; }
        public string Type { get; set; }
        public List<Room> rooms { get; set; }
    }
}
