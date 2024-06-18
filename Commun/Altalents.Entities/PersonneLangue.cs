namespace Altalents.Entities
{
    public partial class PersonneLangue : BaseEntity
    {
        public PersonneLangue()
        {
        }

        public string Niveau { get; set; }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
        public Guid LangueId { get; set; }
        public Reference Langue { get; set; }
    }
}
