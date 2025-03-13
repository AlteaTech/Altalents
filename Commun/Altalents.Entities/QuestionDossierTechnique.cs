namespace Altalents.Entities
{
    public partial class QuestionDossierTechnique : BaseEntity
    {
        public QuestionDossierTechnique()
        {
        }

        public string Question { get; set; }
        public int Ordre { get; set; }
        public string Reponse { get; set; }
        public bool IsRequired { get; set; }
        public bool IsShowDt { get; set; }
        public bool IsDefault { get; set; }

        public Guid? DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
    }
}
