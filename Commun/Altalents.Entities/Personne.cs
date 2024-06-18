namespace Altalents.Entities
{
    public partial class Personne : BaseEntity
    {
        public Personne()
        {
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Trigramme { get; set; }
        public string BoondId { get; set; }
        public string Email { get; set; }

        // Reference de Type disponibilite
        public Guid TypeId { get; set; }
        public Reference Type { get; set; }

        //navigations
        public List<DossierTechnique> DossierTechniques { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Document> Documents { get; set; }
        public List<PersonneLangue> PersonneLangues { get; set; }
        public List<Adresse> Adresses { get; set; }
        public List<Formation> Formations { get; set; }
    }
}
