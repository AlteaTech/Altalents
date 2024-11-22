using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Request
{

    public class ProjetRequestDto
    {

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Taches { get; set; }
    }

}
