using Altalents.Commun.Settings;

using Hangfire;

using MailKit.Net.Smtp;

using Microsoft.Extensions.Options;

using MimeKit;

namespace Altalents.Business.Services
{

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendEmail(string toEmail, string subject, string message)
        {
            SendEmailAsync(toEmail, subject, message).Wait();
        }

        public async Task SendEmailWithRetryAsync(string toEmail, string subject, string message)
        {
            try
            {
                await SendEmailAsync(toEmail, subject, message, default);
            }
            catch
            {
                BackgroundJob.Enqueue(() => SendEmail(toEmail, subject, message));
            }
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message, CancellationToken token = default)
        {
            MimeMessage emailMessage = new();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SmtpUsername));
            foreach (string to in toEmail.Split(';'))
            {
                emailMessage.To.Add(new MailboxAddress(to, to));
            }
            emailMessage.Subject = subject;

            foreach (string cci in _emailSettings.CciMails.Split(';'))
            {
                emailMessage.Bcc.Add(new MailboxAddress(cci, cci));
            }

            BodyBuilder bodyBuilder = new();
            bodyBuilder.HtmlBody = message;

            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, _emailSettings.SecureSocketOptions, token);
                await client.AuthenticateAsync(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword, token);
                await client.SendAsync(emailMessage, token);
                await client.DisconnectAsync(true);
            }
        }
    }
}
