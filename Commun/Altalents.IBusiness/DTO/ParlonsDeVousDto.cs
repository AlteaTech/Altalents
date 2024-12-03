using Altalents.IBusiness.DTO.Request;

namespace Altalents.IBusiness.DTO
{
    public class ParlonsDeVousDto
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Email { get; set; }
        public AdresseDto Adresse { get; set; }
        public string Synthese { get; set; }
        public List<DocumentDto> Documents { get; set; }
    }
}
