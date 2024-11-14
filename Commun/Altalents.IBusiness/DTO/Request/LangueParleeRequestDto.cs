using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Request
{
    public class LangueParleeRequestDto
    {

        [Required]
        public Guid LangueId { get; set; }
        public string Niveau { get; set; }
    }
}
