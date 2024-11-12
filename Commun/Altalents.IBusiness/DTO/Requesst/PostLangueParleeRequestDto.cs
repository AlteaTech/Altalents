using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Requesst
{
    public class PostLangueParleeRequestDto
    {
        public Guid? DossierTechniqueLangueId { get; set; }

        [Required]
        public Guid LangueId { get; set; }

        public string Niveau { get; set; } //ce chanp correspond au value du Select(option) dans l'ecrean et non au libellé ... A CONFIRMER : A voir si on en fait une Enum au niveau de l'entité en BD ? Comment ce genre de cas est géré habituellement dans l'architecture habituellement choisi (comme dans l'app de Volt par exemple)

    }
}
