using Altalents.Commun.Enums;

using AlteaTools.Api.Core.Extensions;

namespace Altalents.IBusiness.DTO
{
    public class UtilisateurDto : BaseUpdatableDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "L'identifiant est obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        public string MotDePasse { get; set; }
        public string NouveauMotDePasse { get; set; }
        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Email { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        public string Telephone { get; set; }
        public string Poste { get; set; }
        [Required]
        public bool IsActif { get; set; }
        public TypeUtilisateurEnum TypeCompte { get; set; } = TypeUtilisateurEnum.Utilisateur;

        public string Statut { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire")]
        public TypeCompteDto TypeCompteSelected { get; set; } = new()
        {
            Value = TypeUtilisateurEnum.Utilisateur
        };
    }
}
