#nullable disable

namespace Altalents.Entities
{
    public partial class SousReference : BaseEntity
    {
        public SousReference()
        {
        }

        public Guid ReferenceId { get; set; }
        public string LibelleFr { get; set; }
        public string Libelle2 { get; set; }
        public string LibelleTransLitLower2 { get; set; }
        public string LibelleTransLitLowerFr { get; set; }
        public int OrdreFr { get; set; }
        public int Ordre2 { get; set; }

        public Reference Reference { get; set; }
        public List<MarqueSousReferenceReference> MarqueSousReferenceReferences { get; set; }
    }
}
