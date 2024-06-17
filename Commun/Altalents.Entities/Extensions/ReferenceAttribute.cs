using Altalents.Entities.Enum;

namespace Altalents.Entities.Extensions
{
    public sealed class ReferenceAttribute : AttributeBase
    {
        public ReferenceAttribute(string libelleFr, string libelle2, EnumTypeReference typeReferenceId, long ticks, int ordreFr, int ordre2) : base(ticks)
        {
            LibelleFr = libelleFr;
            Libelle2 = libelle2;
            TypeReferenceId = typeReferenceId.GetBddId();
            OrdreFr = ordreFr;
            Ordre2 = ordre2;
        }

        public string LibelleFr { get; set; }
        public string Libelle2 { get; set; }
        public Guid TypeReferenceId { get; set; }
        public int OrdreFr { get; set; }
        public int Ordre2 { get; set; }
    }
}
