namespace Altalents.Entities
{
    public partial class Adresse : BaseEntity
    {
        public Adresse()
        {
        }

        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
    }
}
