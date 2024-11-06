using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class LiaisonDto
    {

        [Required]
        public Guid Id { get; set; }

        public string Libelle { get; set; }

        public int note { get; set; }

    }
}
