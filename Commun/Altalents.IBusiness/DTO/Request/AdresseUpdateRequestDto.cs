namespace Altalents.IBusiness.DTO
{
    public class AdresseUpdateRequestDto
    {
        [MaxLength(250)]
        public string Adresse1 { get; set; }
        [MaxLength(250)]
        public string Adresse2 { get; set; }
        [MaxLength(10)]
        public string CodePostal { get; set; }
        [MaxLength(250)]
        public string Ville { get; set; }
        [MaxLength(250)]
        public string Pays { get; set; }
    }
}
