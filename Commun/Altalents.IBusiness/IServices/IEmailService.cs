namespace Altalents.IBusiness.IServices
{
    public interface IEmailService : IInjectableService
    {
        void SendEmail(string toEmail, string subject, string message);
        Task SendEmailAsync(string toEmail, string subject, string message, CancellationToken token = default);
        Task SendEmailWithRetryAsync(string toEmail, string subject, string message);
        string LoadEmailTemplateWithCss(string templateName, string cssFileName, Dictionary<string, string> placeholders);
    }
}
