namespace Altalents.IBusiness.DTO.Request
{
    public class ExperienceDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string IntitulePoste { get; set; }
        [Required]
        public string NomEntreprise { get; set; }
        [Required]
        public string LieuEntreprise { get; set; }
        [Required]
        public ReferenceDto DomaineMetier { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public ReferenceDto TypeContrat { get; set; }
        [Required]
        public bool IsEntrepriseEsnOrInterim { get; set; }
        public DateTime? DateFin { get; set; }
        public List<ProjetOrMissionClientDto> ProjetsOrMissionsClient{ get; set; }
    }
}
