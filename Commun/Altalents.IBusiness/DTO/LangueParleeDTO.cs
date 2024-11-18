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

        public Guid IdLangue { get; set; }

        public string LibelleLangue { get; set; }

        public Guid IdRessourceNiveau { get; set; }

        public string LibelleRessourceNiveau { get; set; }

    }
}
