namespace Altalents.Entities
{
    public partial class DossierTechniqueLangue : BaseEntity
    {
        public DossierTechniqueLangue()
        {
        }

        public string Niveau { get; set; }

        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
        public Guid LangueId { get; set; }
        public Reference Langue { get; set; }
    }
}
