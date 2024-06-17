namespace Altalents.Entities
{
    public partial class Marque : BaseEntity
    {
        public string ReferenceLugt { get; set; }
        public int NumeroLugt { get; set; }
        public string ReferenceLugtLight { get; set; }
        public bool IsFinalize { get; set; }
        public List<MarqueImage> Images { get; set; }
        public List<MarqueSousReferenceReference> MarqueSousReferenceReferences { get; set; }
        public List<MarqueNotice> Notices { get; set; }
        public List<MarqueReferenceLibre> MarqueReferenceLibres { get; set; }
        public List<VueMarqueInitialesSearch> VueMarqueInitialesSearchs { get; set; }
        public List<MarqueRenvois> MarqueRenvois1 { get; set; }
        public List<MarqueRenvois> MarqueRenvois2 { get; set; }
        public double? Largeur { get; set; }
        public double? Hauteur { get; set; }
        public DateTime? DatePublication { get; set; }
        public string Initiales { get; set; }
        public string InitialesTransLitLowerFr { get; set; }
        public string AncienIdAltalents { get; set; }
    }
}
