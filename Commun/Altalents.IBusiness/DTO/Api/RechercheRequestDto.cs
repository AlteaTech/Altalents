namespace Altalents.IBusiness.DTO.Api
{
    public class RechercheRequestDto
    {
        public Guid? NomId { get; set; }
        public string NomFullText { get; set; }
        public Guid? LieuId { get; set; }
        public string LieuFullText { get; set; }
        public ReferenceRechercheRequestDto Texte1 { get; set; }
        public ReferenceRechercheRequestDto Texte2 { get; set; }
        public ReferenceRechercheRequestDto Image1 { get; set; }
        public ReferenceRechercheRequestDto Image2 { get; set; }
        public ReferenceRechercheRequestDto Image3 { get; set; }
        public ReferenceRechercheRequestDto Technique { get; set; }
        public ReferenceRechercheRequestDto Couleur { get; set; }
        public string Texte { get; set; }
        public bool IsExact { get; set; }

        public bool IsUniquementTexteFilter => !NomId.HasValue &&
                                               !LieuId.HasValue &&
                                               Texte1 == null &&
                                               Texte2 == null &&
                                               Image1 == null &&
                                               Image2 == null &&
                                               Image3 == null &&
                                               Technique == null &&
                                               Couleur == null &&
                                               string.IsNullOrEmpty(NomFullText) &&
                                               string.IsNullOrEmpty(LieuFullText);

        public bool IsEmpty => IsUniquementTexteFilter && string.IsNullOrEmpty(Texte);
    }
}
