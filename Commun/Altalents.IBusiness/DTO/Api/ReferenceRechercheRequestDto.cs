namespace Altalents.IBusiness.DTO.Api
{
    public class ReferenceRechercheRequestDto
    {
        public Guid ReferenceId { get; set; }
        public Guid? SousReferenceId { get; set; }
        public string Texte { get; set; }
    }
}
