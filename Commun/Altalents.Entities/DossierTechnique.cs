using System.ComponentModel.DataAnnotations.Schema;

namespace Altalents.Entities
{

    public partial class DossierTechnique : BaseEntity
    {
        public DossierTechnique()
        {
        }

        public Guid TokenAccesRapide { get; set; }
        public decimal? PrixJour { get; set; }
        public string Poste { get; set; }
        public string Synthese { get; set; }
        public string SoftSkills { get; set; }
        public string ZoneGeo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }

        // Reference de Type disponibilite
        public Guid DisponibiliteId { get; set; }
        public Reference Disponibilite { get; set; }
        public Guid StatutId { get; set; }
        public Reference Statut { get; set; }
        public int NumLastEtapValidated { get; set; }
        public Guid CommercialId { get; set; }
        public Utilisateur Commercial { get; set; }
        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
        //navigations
        public List<DocumentComplementaire> DocumentComplementaires { get; set; }
        public List<QuestionDossierTechnique> QuestionDossierTechniques { get; set; }
        public List<Formation> Formations { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<DossierTechniqueLangue> DossierTechniqueLangues { get; set; }
    }
}
