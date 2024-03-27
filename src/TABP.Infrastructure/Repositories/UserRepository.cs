using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUserByCredentialsAsync(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email
            && u.Password == password);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync
            (
                Guid? userId,
                string? firstName,
                string? lastName,
                string? email,
                DateTime? birthDate,
                int? userLevel,
                int pageSize,
                int page
            )
        {
            IQueryable<User> userQuery = _dbContext.Users;
            if (userId != null)
            {
                userQuery = userQuery.Where(u => u.UserId == userId);
            }
            if (firstName != null)
            {
                userQuery = userQuery.Where(u => u.FirstName == firstName);
            }
            if (lastName != null)
            {
                userQuery = userQuery.Where(u => u.LastName == lastName);
            }
            if (email != null)
            {
                userQuery = userQuery.Where(u => u.Email == email);
            }
            if (birthDate != null)
            {
                userQuery = userQuery.Where(u => u.BirthDate == birthDate);
            }
            if (userLevel != null)
            {
                userQuery = userQuery.Where(u => ((int)u.UserLevel) == userLevel);
            }

            return await userQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task DeleteUser(Guid UserId)
        {
            var userToDelete = _dbContext.Users.FirstOrDefault(u => u.UserId.Equals(UserId));
            if (userToDelete != null)
            {
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChangesAsync();
            }
        }


    }
}
