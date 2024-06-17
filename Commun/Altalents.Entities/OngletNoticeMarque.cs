#nullable disable

namespace Altalents.Entities
{
    public partial class OngletNoticeMarque : BaseEntity
    {
        public OngletNoticeMarque()
        {
        }

        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public bool IsDefaultCreation { get; set; }
        public List<MarqueNotice> Notices { get; set; }
        public bool IsSupprimable { get; set; }
    }
}
