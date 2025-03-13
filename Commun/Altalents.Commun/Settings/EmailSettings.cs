using MailKit.Security;

namespace Altalents.Commun.Settings
{
    public class EmailSettings
    {

        public static string Section => "EmailSettings";
        public string SenderName { get; set; }
        public string PrefixMail { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool UseHangfireToSendMail { get; set; }
        public SecureSocketOptions SecureSocketOptions { get; set; }
        public string CciMails { get; set; }
        public string MailsServiceCommercial { get; set; }

    }

}
