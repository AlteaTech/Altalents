using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Entities
{

    public partial class ProjetOrMissionClient : BaseEntity
    {

        public string NomClientOrProjet { get; set; }
        public string DescriptionProjetOrMission { get; set; }
        public string Taches { get; set; }
        public string Lieu { get; set; }
        public decimal? Budget { get; set; }
        public string CompositionEquipe { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public Guid? DomaineMetierId { get; set; }
        public Reference DomaineMetier { get; set; }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }

        public List<LiaisonProjetTechnologie> LiaisonProjetTechnologies { get; set; }
        public List<LiaisonProjetMethodologie> LiaisonProjetMethodologies { get; set; }
        public List<LiaisonProjetCompetence> LiaisonProjetCompetences { get; set; }
        public List<LiaisonProjetOutil> LiaisonProjetOutils { get; set; }

    }
}
