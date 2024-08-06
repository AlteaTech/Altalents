using Newtonsoft.Json;

namespace Altalents.IBusiness.DTO.Requesst
{
    public class DocumentInfoDto
    {
        [Required]
        public string MimeType { get; set; }

        public DateTime? DateExpiration { get; set; }

        [Required]
        public string NomFichier { get; set; }
        public string Commentaire { get; set; }
    }
}
