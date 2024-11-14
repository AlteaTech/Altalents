using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.IBusiness.DTO.Request;

namespace Altalents.IBusiness.DTO
{
    public class RecapitulatifDtDto
    {
        public List<FormationCertificationDto> Formations { get; set; }
        public List<FormationCertificationDto> Certifications { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<LangueParleeDto> Langues { get; set; }
        public List<QuestionnaireDto> Questionnaires { get; set; }
        public CompetencesGroupByTypeDto Competences { get; set; }

    }


    public class CompetencesGroupByTypeDto
    {
        public List<CompetenceDto> Competences { get; set; } = new List<CompetenceDto>();
        public List<CompetenceDto> Methodologies { get; set; } = new List<CompetenceDto>();
        public List<CompetenceDto> Outils { get; set; } = new List<CompetenceDto>();
        public List<CompetenceDto> Technologie { get; set; } = new List<CompetenceDto>();

    }

}
