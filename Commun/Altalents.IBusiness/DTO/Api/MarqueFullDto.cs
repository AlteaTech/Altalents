namespace Altalents.IBusiness.DTO.Api
{
    public class MarqueFullDto
    {
        public Guid IdMarque { get; set; }
        public string ReferenceLugt { get; set; }
        public string NomPrincipal { get; set; }
        public string Hauteur { get; set; }
        public string Largeur { get; set; }
        public string Initiales { get; set; }
        public List<ImageLightDto> Images { get; set; }
        public List<NoticeMarqueLightDto> Notices { get; set; }
        public List<MarqueRenvoisLightDto> Renvois { get; set; }
        public List<MarqueTypeReferenceDto> References { get; set; }
    }
}
