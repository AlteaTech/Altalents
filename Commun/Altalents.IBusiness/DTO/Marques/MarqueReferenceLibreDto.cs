using Altalents.Entities.Enum;

namespace Altalents.IBusiness.DTO.Marques
{
    public class MarqueReferenceLibreDto : BaseUpdatableDto
    {
        public Guid Id { get; set; }
        public Guid IdMarque { get; set; }
        [Required(ErrorMessage = "Le texte est obligatoire.")]
        public string Texte { get; set; }
        public EnumTypeMarqueReferenceLibre Type { get; set; }

        public new bool IsSupprimable => true;
        public new bool IsModifiable => true;
    }
}
