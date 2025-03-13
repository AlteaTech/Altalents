using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class ProjetOrMissionClientDto
    {

        [Required]
        public string Id { get; set; }
        public string NomClientOrProjet { get; set; }
        public string DescriptionProjetOrMission { get; set; }
        public string Taches { get; set; }
        public string Lieu { get; set; }
        public string CompositionEquipe { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public ReferenceDto DomaineMetier { get; set; }
        public List<ReferenceDto> Technologies { get; set; }
        public List<ReferenceDto> Methodologies { get; set; }
        public List<ReferenceDto> Competences { get; set; }
        public List<ReferenceDto> Outils { get; set; }
    }

}
