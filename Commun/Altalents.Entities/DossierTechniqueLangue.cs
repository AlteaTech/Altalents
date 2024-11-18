namespace Altalents.Entities
{
    public partial class DossierTechniqueLangue : BaseEntity
    {
        public DossierTechniqueLangue()
        {
        }

        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
        public Guid LangueId { get; set; }
        public Reference Langue { get; set; }
        public Guid? NiveauId { get; set; }
        public Reference Niveau { get; set; }
    }
}
