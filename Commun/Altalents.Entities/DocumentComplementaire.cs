using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class DocumentComplementaire : FileEntity
    {
        public DocumentComplementaire()
        {
        }

        public string Commentaire { get; set; }
        // Reference de Type disponibilite
        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }
    }
}
