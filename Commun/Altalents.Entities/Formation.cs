using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Formation : BaseFormationEntity
    {
        public Formation()
        {
        }

        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
    }
}
