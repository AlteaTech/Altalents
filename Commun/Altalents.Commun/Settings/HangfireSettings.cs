namespace Altalents.Commun.Settings
{
    public class HangfireSettings
    {
        public static string Section => "HangfireSettings";
        public bool IsActivated { get; set; }
        public bool DashBoardReadOnly { get; set; }
        public bool HasDashBoard { get; set; }
        public int WorkerCount { get; set; }
    }
}
