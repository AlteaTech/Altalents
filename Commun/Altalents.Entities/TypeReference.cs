#nullable disable

namespace Altalents.Entities
{
    public partial class TypeReference : BaseEntity
    {
        public TypeReference()
        {
        }

        public string Code { get; set; }
        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public bool WithSecondeLangue { get; set; }
        public bool WithSousReference { get; set; }

        public List<Reference> References { get; set; } = new List<Reference>();
    }
}
