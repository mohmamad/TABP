namespace TABP.Domain.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(string recieverEmail, string recieverName, string subject, string message);
        public Task prepareInvoiceEmailMessage(string userName, string email, List<double> pricePerDay, List<int> roomNumber, List<string> hotelName, List<int> NumberOfDays);
        public Task PrepareResetPasswordCodeEmail(string userName, string email, string code);
    }
}
