#nullable disable


namespace Altalents.Entities
{
    public partial class Reference : BaseEntity
    {
        public Reference()
        {
        }

        public Guid TypeReferenceId { get; set; }
        public string Libelle2 { get; set; }
        public string LibelleFr { get; set; }
        public string LibelleTransLitLower2 { get; set; }
        public string LibelleTransLitLowerFr { get; set; }
        public int Ordre { get; set; }
        public int Ordre2 { get; set; }

        public TypeReference TypeReference { get; set; }
        public List<SousReference> SousReferences { get; set; }
        public List<MarqueSousReferenceReference> MarqueSousReferenceReferences { get; set; }
    }
}
