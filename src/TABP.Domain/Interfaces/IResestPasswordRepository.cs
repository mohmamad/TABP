namespace TABP.Domain.Interfaces
{
    public interface IResestPasswordRepository
    {
        public Task<bool> AddResetPasswordCode(string email, string code);
        public Task<bool> IsCodeValid(string code);
    }
}
