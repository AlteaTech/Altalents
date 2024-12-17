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

        public EmailService(IOptions<EmailSettings> emailSetting)
        {
            _emailSettings = emailSetting.Value;
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
            subject = $"{_emailSettings.PrefixMail} - {subject}";
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

            using (SmtpClient client = new())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, _emailSettings.SecureSocketOptions, token);
                await client.AuthenticateAsync(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword, token);
                await client.SendAsync(emailMessage, token);
                await client.DisconnectAsync(true, token);
            }
        }

        public string LoadEmailTemplateWithCss(string templateName, string cssFileName, Dictionary<string, string> placeholders)
        {

            string projectRoot = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;

            // Charger le fichier HTML
            string templatePath = Path.Combine(projectRoot, "Templates", "Emails", templateName);
            string templateContent = File.ReadAllText(templatePath, Encoding.UTF8);

            // Charger le fichier CSS
            string cssPath = Path.Combine(projectRoot, "Templates", "Emails", "Styles", cssFileName);
            string cssContent = File.ReadAllText(cssPath, Encoding.UTF8);

            // Injecter les styles CSS dans le HTML (via une balise <style>)
            string styledHtml = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <style>
                        {cssContent}
                    </style>
                </head>
                <body>
                    {templateContent}
                </body>
                </html>";

            // Injecter les placeholders
            foreach (var placeholder in placeholders)
            {
                styledHtml = styledHtml.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
            }

            // Inline le CSS via PreMailer
            var result = PreMailer.Net.PreMailer.MoveCssInline(styledHtml);

            return result.Html;
        }




    }
}
