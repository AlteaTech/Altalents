using Altalents.Entities.Enum;

namespace Altalents.Entities
{
    public partial class TexteDivers : BaseEntity
    {
        public TexteDivers()
        {

        }

        public string TitreFr { get; set; }
        public string TitreEn { get; set; }
        public string DetailFr { get; set; }
        public string DetailEn { get; set; }
        public EnumTypeTexteDivers Type { get; set; }
    }
}
