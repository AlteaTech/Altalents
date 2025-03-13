namespace Altalents.IBusiness.IServices
{
    public interface IEmailService : IInjectableService
    {
        void SendEmail(string toEmail, string subject, string message, bool sendCcToCciMailsList = true);
        Task SendEmailAsync(string toEmail, string subject, string message, bool sendCcToCciMailsList = true, CancellationToken token = default);
        Task SendEmailWithRetryAsync(string toEmail, string subject, string message, bool sendCcToCciMailsList = true);
        string LoadEmailTemplateWithCss(string templateName, string cssFileName, Dictionary<string, string> placeholders);
    }
}
