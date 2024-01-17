using Microsoft.EntityFrameworkCore;
using TABP.API.Models;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TABPDbContext _dbContext;
        public UserRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByCredentialsAsync(string email , string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email 
            && u.Password == password);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
