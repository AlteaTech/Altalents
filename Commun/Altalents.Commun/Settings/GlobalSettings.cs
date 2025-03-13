using AlteaTools.Api.Core.Settings;

namespace Altalents.Commun.Settings
{
    public class GlobalSettings : BaseGlobalSettings
    {
        public static string Section => "GlobalSettings";
        public int TimeoutSessionSeconds { get; set; }
        public bool AutoMigrate { get; set; }
        public string BaseUrl { get; set; }
    }
}
