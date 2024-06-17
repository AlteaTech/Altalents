using Altalents.Commun.Settings;

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

        public void SendEmailForCSV(string toEmail, string subject, string message, byte[] attachmentData = null, string attachmentFileName = null)
        {
            SendEmailForCSVAsync(toEmail, subject, message, attachmentData, attachmentFileName).Wait();
        }

        public async Task SendEmailForCSVAsync(string toEmail, string subject, string message, byte[] attachmentData = null, string attachmentFileName = null, CancellationToken token = default)
        {
            MimeMessage emailMessage = new();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            foreach (string to in toEmail.Split(';'))
            {
                emailMessage.To.Add(new MailboxAddress(to, to));
            }
            emailMessage.Subject = subject;

            BodyBuilder bodyBuilder = new();
            bodyBuilder.HtmlBody = message;

            if (attachmentData != null && attachmentData.Length > 0)
            {


                // Attacher la pièce jointe à partir des données en byte[]
                MimePart attachment = new MimePart("text", "csv")
                {
                    Content = new MimeContent(new MemoryStream(attachmentData)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = attachmentFileName
                };

                bodyBuilder.Attachments.Add(attachment);
            }
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
