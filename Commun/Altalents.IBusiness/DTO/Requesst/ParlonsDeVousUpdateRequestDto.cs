namespace Altalents.IBusiness.DTO.Requesst
{
    public class ParlonsDeVousUpdateRequestDto
    {
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public AdresseUpdateRequestDto Adresse { get; set; }
    }
}
