using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.IBusiness.DTO
{
    public class RecapitulatifDtDto
    {
        [Required]
        public Guid Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public AdresseDto Adresse { get; set; }
        public List<string> Telephones { get; set; }
        public string Email { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        //public List<FormationDto> Formations { get; set; }
        //public List<CertificationDto> Certifications { get; set; }
        //public List<LangueDto> Langues { get; set; }
        public List<CompetenceDto> Competences { get; set; }  // Nouvelle section pour les compétences
        public List<DocumentDto> Documents { get; set; }
        public List<QuestionnaireDto> Questionnaires { get; set; }

    }
}
