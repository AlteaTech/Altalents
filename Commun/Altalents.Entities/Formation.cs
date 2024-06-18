using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Formation : BaseFormationEntity
    {
        public Formation()
        {
        }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
    }
}
