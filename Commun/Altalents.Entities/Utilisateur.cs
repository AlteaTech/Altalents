namespace Altalents.Entities
{
    public partial class Utilisateur : BaseEntity
    {
        public Utilisateur()
        {
        }

        public string Nom { get; set; }
        public string Login { get; set; }
        public string MotDePasseCrypte { get; set; }
        public string Email { get; set; }
        public bool IsActif { get; set; }
        public bool IsSupprimable { get; set; }
        public bool IsModifiable { get; set; }
        public bool IsCommercial { get; set; }
        public bool IsDefault { get; set; }

        public List<DossierTechnique> DossierTechniques { get; set; }
    }
}
