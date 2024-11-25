namespace Altalents.IBusiness.DTO.Request
{
    public class ExperienceDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string IntitulePoste { get; set; }
        [Required]
        public string Entreprise { get; set; }
        [Required]
        public string Lieu { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DomaineMetier { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public ReferenceDto TypeContrat { get; set; }
        public DateTime? DateFin { get; set; }
        public decimal? Budget { get; set; }
        public string ClientFinal { get; set; }
        public List<ReferenceDto> Technologies{ get; set; }
        public List<ReferenceDto> Methodologies { get; set; }
        public List<ReferenceDto> Competences { get; set; }
        public List<ReferenceDto> Outils { get; set; }
        public List<ProjetDto> Projets{ get; set; }
    }
}
