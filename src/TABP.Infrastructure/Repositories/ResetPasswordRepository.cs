using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;


namespace TABP.Infrastructure.Repositories
{
    public class ResetPasswordRepository : IResestPasswordRepository
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
            ResetPasswordCode resetPasswordCode = new ResetPasswordCode { Code = code, Id = new Guid(), UserId = user.UserId, CreatedDate = DateTime.Now};
            await _dbContext.ResetPasswordCodes.AddAsync(resetPasswordCode);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsCodeValid(string code)
        {
            ResetPasswordCode rcode = _dbContext.ResetPasswordCodes.Where(r => r.Code == code).ToList()[0];
            if(rcode.CreatedDate <= DateTime.Now.AddMinutes(5))
            {
                return true;
            }
            return false;
        }
    }
}
