using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Certification : BaseFormationEntity
    {
        public Certification()
        {
        }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
    }
}
