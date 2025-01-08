using Altalents.Entities;

namespace Altalents.IBusiness.DTO.Request
{
    public class ExperienceRequestDto
    {
        [Required]
        public string IntitulePoste { get; set; }
        [Required]
        public string Entreprise { get; set; }

        public string Lieu { get; set; }
        [Required]
        public Guid DomaineMetierId { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public Guid? TypeContratId { get; set; }
        public DateTime? DateFin { get; set; }
        public bool IsEntrepriseEsnOrInterim { get; set; }
        public List<ProjetOrMissionClientRequestDto> ProjetsOrMissionsClient { get; set; }
    }
}
