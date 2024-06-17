namespace Altalents.MVC.Models.Marque
{
    public class PartialViewUploadFileToMarqueModel : PartialViewUpdateMarqueModelBase
    {
        public bool IsEnabled { get; set; }
        public string[] AllowedExtensions { get; set; }
        public string AcceptExtensions => $".{string.Join(",.", AllowedExtensions)}";
    }
}
