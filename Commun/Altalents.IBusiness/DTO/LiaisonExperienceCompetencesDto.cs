using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class LiaisonExperienceCompetencesDto
    {

        [Required]
        public Guid Id { get; set; }

        public string Libelle { get; set; }

        public int Note { get; set; }

    }
}
