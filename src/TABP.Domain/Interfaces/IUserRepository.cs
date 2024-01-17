using TABP.Domain.Entities;

namespace TABP.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByCredentialsAsync(string email , string password);
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
