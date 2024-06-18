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
        public int Numero { get; set; }
        public string Commercial { get; set; }

        // Reference de Type disponibilite
        public Guid DisponibiliteId { get; set; }
        public Reference Disponibilite { get; set; }
        public Guid StatutId { get; set; }
        public Reference Statut { get; set; }
        // Reference de Type disponibilite
        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }

        //navigations
        public List<DocumentComplementaire> DocumentComplementaires { get; set; }
        public List<QuestionDossierTechnique> QuestionDossierTechniques { get; set; }
    }
}
