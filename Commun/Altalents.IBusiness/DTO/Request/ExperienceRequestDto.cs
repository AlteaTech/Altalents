using Altalents.Entities;

namespace Altalents.IBusiness.DTO.Request
{
    public class ExperienceRequestDto
    {
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
        public Guid? TypeContratId { get; set; }


        public DateTime? DateFin { get; set; }
        public decimal? Budget { get; set; }
        public string ClientFinal { get; set; }

        public List<Guid> TechnologieIds { get; set; }
        public List<Guid> MethodologieIds { get; set; }
        public List<Guid> CompetenceIds { get; set; }
        public List<Guid> OutilIds { get; set; }
    }
}
