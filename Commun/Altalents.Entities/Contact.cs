using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Contact : BaseEntity
    {
        public Contact()
        {
        }

        public string Valeur { get; set; }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
        public Guid TypeId { get; set; }
        public Reference Type { get; set; }
    }
}
