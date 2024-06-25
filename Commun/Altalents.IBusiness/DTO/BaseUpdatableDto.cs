using Altalents.Commun.Enums;

namespace Altalents.IBusiness.DTO
{
    public class BaseUpdatableDto
    {
        [Required]
        public bool IsSupprimable { get; set; }
        [Required]
        public bool IsModifiable { get; set; }
        [Required]
        public bool IsCommercial { get; set; }
        public TypeUtilisateurEnum? TypeCompte { get; set; }
        public string Telephone { get; set; }
        public string Poste { get; set; }
    }
}
