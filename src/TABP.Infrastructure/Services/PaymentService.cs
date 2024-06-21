using Square.Apis;
using Square.Exceptions;
using Square.Models;
using TABP.Domain.Interfaces;

namespace TABP.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsApi _paymentsApi;

        public PaymentService(IPaymentsApi paymentsApi)
        {
            _paymentsApi = paymentsApi;
        }

        public async Task<string> PayAsync(string cardDetailsToken,
            string idempotencyKey,
            double amount,
            string currency)
        {
            long amountLong = (long)(amount * 100);
            var createPaymentReq = new CreatePaymentRequest.Builder
                (
                    cardDetailsToken,
                    idempotencyKey
                )
                .AmountMoney
                (
                   new Money.Builder()
                    .Amount(amountLong)
                    .Currency(currency)
                    .Build()
                )
                .Autocomplete(true)
                .Build();
            try
            {
                CreatePaymentResponse result = await _paymentsApi.CreatePaymentAsync(createPaymentReq);
                var errors = result.Errors;

                if (errors != null && errors.Count != 0)
                {
                    return errors.ToList()[0].Detail;
                }

                return "Payment was successful";
            }
            catch (ApiException e)
            {
                throw;
            }
        }
    }
}
