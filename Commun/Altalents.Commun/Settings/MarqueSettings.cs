namespace Altalents.Commun.Settings
{
    public class MarqueSettings
    {
        public static string Section => "MarqueSettings";
        public int MaxImageCount { get; set; }
        public int MinImageCount { get; set; }
        public string[] AllowedExtensions { get; set; }
        public int TailleMaxImageOctet { get; set; }
        public int DelaiMoisNouveaute { get; set; }
        public string PathDetailMarqueFront { get; set; }
        public string PathPrevisualisationMarqueFront { get; set; }
    }
}
