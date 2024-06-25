
using System.ComponentModel.DataAnnotations;

namespace Altalents.Commun.Enums
{
    public enum TypeUtilisateurEnum
    {
        [Display(Name = "Admin")]
        Admin = 0,
        [Display(Name = "Utilisateur")]
        Utilisateur = 1,
        [Display(Name = "Manager")]
        Manager = 2
    }
}
