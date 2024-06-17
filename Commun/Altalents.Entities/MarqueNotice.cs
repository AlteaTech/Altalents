namespace Altalents.Entities
{
    public partial class MarqueNotice : BaseEntity
    {
        public string Texte { get; set; }
        public string TexteBrut { get; set; }
        public bool IsPublie { get; set; }
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
        public Guid OngletNoticeMarqueId { get; set; }
        public OngletNoticeMarque OngletNoticeMarque { get; set; }
    }
}
