namespace Altalents.MVC.Models.Marque
{
    public class PartialViewNoticesMarqueModel : PartialViewUpdateMarqueModelBase
    {
        public bool IsFinalized { get; set; }
        public List<NoticeMarqueDto> Notices { get; set; }
    }
}
