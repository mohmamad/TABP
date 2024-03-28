namespace TABP.Domain.Interfaces
{
    public interface IInvoiceEmailService
    {
        public Task SendInvoiceEmail(string recieverEmail, string recieverName, string subject, string message);
        public Task prepareEmailMessage(string userName, string email, List<double> pricePerDay, List<int> roomNumber, List<string> hotelName, List<int> NumberOfDays);
    }
}
