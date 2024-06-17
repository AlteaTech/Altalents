using Altalents.Entities.Enum;

namespace Altalents.Entities
{
    public partial class VueMarqueInitialesSearch : BaseEntity
    {
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
        public string TexteTransLitLowerFr { get; set; }
        public int Total { get; set; }
    }
}
