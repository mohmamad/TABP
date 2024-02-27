namespace TABP.API.DTOs.CartItemDtos
{
    public class CartItemDto
    {
        public Guid CartItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<Link> Links { get; set; }
     }
}
