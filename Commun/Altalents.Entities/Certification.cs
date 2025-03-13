using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Certification : BaseFormationEntity
    {
        public Certification()
        {
        }

        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
    }
}
