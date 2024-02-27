using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        public Task AddToCartAsync(CartItem cartItem);
        public Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(Guid userId);
        public Task<bool> SaveChangesAsync();
        public Task<bool> DeleteCartItemAsync(Guid cartItemId, Guid userId);
    }
}
