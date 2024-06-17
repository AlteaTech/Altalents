namespace Altalents.IBusiness.IServices
{
    public interface IEmailService
    {
        void SendEmailForCSV(string toEmail, string subject, string message, byte[] attachmentData = null, string attachmentFileName = null);

        Task SendEmailForCSVAsync(string toEmail, string subject, string message, byte[] attachmentData = null, string attachmentFileName = null, CancellationToken token = default);
    }
}
