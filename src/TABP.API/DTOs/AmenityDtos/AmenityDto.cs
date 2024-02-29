namespace TABP.API.DTOs.AmenityDtos
{
    public class AmenityDto
    {
        public Guid HotleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Link> Links { get; set; }
    }
}
