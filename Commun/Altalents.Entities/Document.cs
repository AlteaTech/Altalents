using Altalents.Commun.Enums;
using Altalents.Entities.BaseEntities;

namespace Altalents.Entities
{
    public partial class Document : FileEntity
    {
        public Document()
        {
        }

        public TypeDocumentEnum TypeDocument { get; set; }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
        //public Guid TypeId { get; set; }
        //public Reference Type { get; set; }
    }
}
