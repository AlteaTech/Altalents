using Altalents.Commun.Enums;

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
        public string Telephone { get; set; }
        public string Poste { get; set; }
        public bool IsActif { get; set; }
        public bool IsSupprimable { get; set; }
        public bool IsModifiable { get; set; }
        public TypeUtilisateurEnum TypeCompte { get; set; }
        public bool IsDefault { get; set; }
        public string Statut
        {
            get
            {
                return TypeCompte.GetDisplayName(false);
            }
            set { }
        }

        public List<DossierTechnique> DossierTechniques { get; set; }
    }
}
