namespace Altalents.IBusiness.DTO.Request
{
    public class ParlonsDeVousUpdateRequestDto
    {
        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Telephone1 { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string zoneGeo { get; set; }

        [Required]
        public AdresseUpdateRequestDto Adresse { get; set; }

        public string Synthese { get; set; }

        public string SoftSKills { get; set; }

        public DocumentDto Cv { get; set; }
    }
}
