using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Text;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;
using TABP.Infrastructure.Repositories;

namespace TABP.Infrastructure.Services
{
    public class InvoiceEmailService : IInvoiceEmailService
    {
        private readonly string _senderEmail;
        private readonly string _senderName;

        public InvoiceEmailService(string senderEmail, string senderName)
        {
            _senderEmail = senderEmail;
            _senderName = senderName;
        }

        public async System.Threading.Tasks.Task prepareEmailMessage(string userName, string email, List<double> pricePerDay, List<int> roomNumber,List<string> hotelName, List<int> NumberOfDays)
        {

            int count = 0;

            StringBuilder message = new StringBuilder();

            string format = "{0,-20} {1,-12} {2,-15} {3,-10}";


            string subject = "Booking Invoice.";
            message.AppendLine("<html><body>");
            message.AppendLine("<h2 style=\"color:blue;\">Booking Invoice</h2>");
            message.AppendLine("<table border=\"1\">");
            message.AppendLine("<tr>");
            message.AppendLine("<th style=\"color:blue;\">Hotel name</th>");
            message.AppendLine("<th style=\"color:blue;\">Room number</th>");
            message.AppendLine("<th style=\"color:blue;\">Number of days</th>");
            message.AppendLine("<th style=\"color:blue;\">Price per day</th>");
            message.AppendLine("</tr>");

            double totalPrice = 0.0;
            foreach (var number in roomNumber)
            {

                message.AppendLine("<tr>");
                message.AppendLine($"<td>{hotelName[count]}</td>");
                message.AppendLine($"<td>{number}</td>");
                message.AppendLine($"<td>{NumberOfDays[count]}</td>");
                message.AppendLine($"<td>{pricePerDay[count]}</td>");
                message.AppendLine("</tr>");
                count++;
                
            }

            message.AppendLine("</table>");
            totalPrice = pricePerDay.Sum(); 
            message.AppendLine($"<p>Total price = {totalPrice}</p>");
            message.AppendLine("<p>Thanks for choosing us.</p>");
            message.AppendLine("</body></html>");

            string totalMsg = message.ToString();

            await SendInvoiceEmail(email, userName, subject, totalMsg);
        }

        public async System.Threading.Tasks.Task SendInvoiceEmail(string recieverEmail, string recieverName, string subject, string message)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender sender = new SendSmtpEmailSender(_senderName, _senderEmail);

            SendSmtpEmailTo reciever1 = new SendSmtpEmailTo(recieverEmail, recieverName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(reciever1);

            string HtmlContent = null;
            string TextContent = message;

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                Console.WriteLine(result.ToJson());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
