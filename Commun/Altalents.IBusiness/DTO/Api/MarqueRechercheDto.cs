namespace Altalents.IBusiness.DTO.Api
{
    public class MarqueRechercheDto
    {
        public Guid IdMarque { get; set; }
        public string PathImagePrincipale { get; set; }
        public string ReferenceLugt { get; set; }
        public int NumeroLugt { get; set; }
        public string NomPrincipal { get; set; }
        public string ReferenceLugtFull { get; set; }
        public string Initiales { get; set; }
    }
}
