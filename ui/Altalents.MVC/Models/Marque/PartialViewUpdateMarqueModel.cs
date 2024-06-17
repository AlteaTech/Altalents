using Altalents.Commun.Settings;

namespace Altalents.MVC.Models.Marque
{
    public class PartialViewUpdateMarqueModel : PartialViewUpdateMarqueModelBase
    {
        public MarqueSettings Settings { get; set; }
        public DateTime? DatePublication { get; set; }
    }
}
