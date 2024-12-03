using Newtonsoft.Json;

namespace Altalents.IBusiness.DTO.Request
{
    public class DocumentInfoDto
    {
        [Required]
        public string MimeType { get; set; }

        [Required]
        public string NomFichier { get; set; }
        public string Commentaire { get; set; }


    }
}
