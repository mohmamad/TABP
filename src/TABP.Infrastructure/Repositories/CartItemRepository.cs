using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly TABPDbContext _dbContext;
        public CartItemRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
           await _dbContext.CartItems.AddAsync(cartItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(Guid userId)
        {
            var cartItems = await _dbContext.CartItems.Where(c => c.UserId == userId && ((int)c.RoomStatus) == 1).ToListAsync();

            return cartItems;
        }

        public async Task<bool> DeleteCartItemAsync(Guid cartItemId, Guid userId)
        {
            var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(c => c.CartItemId == cartItemId && c.UserId == userId && (int)c.RoomStatus == 1);
            if(cartItem != null)
            {
                _dbContext.Remove(cartItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0 ;
        }
    }
}
