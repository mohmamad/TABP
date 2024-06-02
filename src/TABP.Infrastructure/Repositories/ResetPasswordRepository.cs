using TABP.Domain.Entities;

namespace TABP.Infrastructure.Repositories
{
    public class ResetPasswordRepository
    {
        private readonly TABPDbContext _dbContext;
        public ResetPasswordRepository(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddResetPasswordCode(string email, string code)
        {

            if (!_dbContext.Users.Any(u => u.Email == email))
            {
                return false;
            }

            User user = _dbContext.Users.Where(u => u.Email == email).ToList()[0];
            ResetPasswordCode resetPasswordCode = new ResetPasswordCode { code = code, Id = new Guid(), UserId = user.UserId};
            await _dbContext.ResetPasswordCodes.AddAsync(resetPasswordCode);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
