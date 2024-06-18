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

        // Reference de Type disponibilite
        public Guid DisponibiliteId { get; set; }
        public Reference Disponibilite { get; set; }

        //navigations
        public List<DocumentComplementaire> DocumentComplementaires { get; set; }
        public List<QuestionDossierTechnique> QuestionDossierTechniques { get; set; }
    }
}
