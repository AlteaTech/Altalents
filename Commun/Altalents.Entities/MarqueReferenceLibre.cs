using Altalents.Entities.Enum;

namespace Altalents.Entities
{
    public partial class MarqueReferenceLibre : BaseEntity
    {
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
        public string Texte { get; set; }
        public string TexteTransLitLowerFr { get; set; }
        public EnumTypeMarqueReferenceLibre Type { get; set; }
    }
}
