namespace TABP.Domain.Interfaces
{
    public interface ITransactionService
    {
        public Task BeginTransaction();
        public Task CommitTransaction();
    }
}
