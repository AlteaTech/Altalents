using Altalents.Commun.Enums;

namespace Altalents.Entities
{
    public partial class Reference : BaseEntity
    {
        public Reference()
        {
        }

        public string Libelle { get; set; }
        public TypeReferenceEnum Type { get; set; }
        public SousTypeReferenceEnum? SousType { get; set; }
        public int OrdreTri { get; set; }
        public List<DossierTechnique> DossierTechniques { get; set; }
        public List<Personne> Personnes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Document> Documents { get; set; }
        public List<PersonneLangue> PersonneLangues { get; set; }
    }
}
