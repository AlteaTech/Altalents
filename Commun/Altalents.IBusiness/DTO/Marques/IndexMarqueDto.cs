namespace Altalents.IBusiness.DTO.Marques
{
    public class IndexMarqueDto : IndexMarqueDtoBase
    {
        public List<ReferenceLightDto> ReferenceNoms { get; set; }
        public List<ReferenceLightDto> ReferencePays { get; set; }
        public List<SousReferenceLightDto> SousReferencePays { get; set; }
        public List<ReferenceLightDto> ReferenceTextes { get; set; }
        public List<SousReferenceLightDto> SousReferenceTextes { get; set; }
        public List<ReferenceLightDto> ReferenceImages { get; set; }
        public List<SousReferenceLightDto> SousReferenceImages { get; set; }
        public List<ReferenceLightDto> ReferenceCouleurs { get; set; }
        public List<SousReferenceLightDto> SousReferenceCouleurs { get; set; }
        public List<ReferenceLightDto> ReferenceContours { get; set; }
        public List<SousReferenceLightDto> SousReferenceContours { get; set; }
        public List<ReferenceLightDto> ReferenceCategories { get; set; }
        public List<SousReferenceLightDto> SousReferenceCategories { get; set; }
        public List<ReferenceLightDto> ReferenceLocalisations { get; set; }
        public List<SousReferenceLightDto> SousReferenceLocalisations { get; set; }
        public List<ReferenceLightDto> ReferenceTechniques { get; set; }
        public List<SousReferenceLightDto> SousReferenceTechniques { get; set; }
        public ReferenceLightDto NomPrincipal { get; set; }
        public int TotalElementACharger { get; set; }
    }
}
