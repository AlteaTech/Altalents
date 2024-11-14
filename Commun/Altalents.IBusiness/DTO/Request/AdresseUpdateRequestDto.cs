namespace Altalents.IBusiness.DTO
{
    public class AdresseUpdateRequestDto
    {
        [MaxLength(250)]
        [Required]
        public string Adresse1 { get; set; }
        [MaxLength(250)]
        public string Adresse2 { get; set; }
        [MaxLength(10)]
        [Required]
        public string CodePostal { get; set; }
        [MaxLength(250)]
        [Required]
        public string Ville { get; set; }
        [MaxLength(250)]
        [Required]
        public string Pays { get; set; }
    }
}
