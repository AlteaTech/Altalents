using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class LangueParleeDto
    {

        [Required]
        public Guid DossierTechniqueLangueId { get; set; }

        public Guid IdLangue { get; set; }          // Niveau de maîtrise (ex: Basique)

        public string LibelleLangue { get; set; }          // Niveau de maîtrise (ex: Basique)

        public string Niveau { get; set; }          // Niveau de maîtrise (ex: Basique)

    }
}
