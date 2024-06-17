namespace Altalents.Commun.Settings
{
    public class PurgeSettings
    {
        public static string Section => "PurgeSettings";
        public long TimeToLiveMarqueNonFinalizeSeconds { get; set; }
    }
}
