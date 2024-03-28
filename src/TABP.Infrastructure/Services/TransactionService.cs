using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly TABPDbContext _dbContext;
        public TransactionService(TABPDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task BeginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _dbContext.Database.CurrentTransaction.CommitAsync();
        }

    }
}
