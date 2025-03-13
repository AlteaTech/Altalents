using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class AllAboutFormationsDto
    {
        public List<FormationCertificationDto> Formations { get; set; } = new List<FormationCertificationDto>();        // Liste de formations
        public List<FormationCertificationDto> Certifications { get; set; } = new List<FormationCertificationDto>();  // Liste de certifications
        public List<LangueParleeDto> LanguesParlees { get; set; } = new List<LangueParleeDto>();    // Liste de langues parlées
    }
}
