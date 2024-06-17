using Altalents.Entities.Enum;

namespace Altalents.IBusiness.DTO
{
    public class TexteDiversDto
    {
        public Guid Id { get; set; }
        public string TitreFr { get; set; }
        public string TitreEn { get; set; }
        public string DetailFr { get; set; }
        public string DetailEn { get; set; }
        public EnumTypeTexteDivers Type { get; set; }
    }
}
