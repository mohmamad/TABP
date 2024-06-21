namespace TABP.Domain.Interfaces
{
    public interface IPaymentService
    {
        public Task<string> PayAsync(string cardDetailsToken,
            string idempotencyKey,
            double amount,
            string currency);

    }
}
