namespace TABP.Domain.Entities
{
    public class RoomImage
    {
        public Guid RoomImageId { get; set; }
        public string ImageBath { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
