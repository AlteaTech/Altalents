using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Requesst
{
    public class LiaisonExperienceUpdateNiveauDto
    {
        [Required]
        public Guid LiaisonId { get; set; }

        [Required]
        public string TypeLiaisonCode { get; set; }

        [Required]
        public int Note { get; set; }

    }
}
