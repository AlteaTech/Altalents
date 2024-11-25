using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class ProjetOrMissionClientDto
    {
        public string NomClientOrProjet { get; set; }
        public string DescriptionProjetOrMission { get; set; }
        public string Taches { get; set; }
        public string Lieu { get; set; }
        public string CompositionEquipe { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public ReferenceDto DomaineMetier { get; set; }
    }

}
