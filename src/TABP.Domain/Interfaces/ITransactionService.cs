using System.Transactions;
using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface ITransactionService
    {
        public Task PerformTransactionAsync(Transaction transaction, Guid userId);
        public Task<IEnumerable<string>> AddBookingFromCartTransactionAsync(Transaction transaction, Guid userId);
    }
}
