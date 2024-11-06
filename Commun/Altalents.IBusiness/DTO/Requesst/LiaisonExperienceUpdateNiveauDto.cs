using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Requesst
{
    public class LiaisonExperienceUpdateNiveauDto
    {
        public Guid LiaisonId { get; set; }

        public string TypeLiaisonCode { get; set; }

        public int Note { get; set; }

    }
}
