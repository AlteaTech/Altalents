using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Request
{
    public class FormationCertificationRequestDto
    {
        public string FormationOrCertificationEnumCode { get; set; } 
        public string Libelle { get; set; }         
        public string Niveau { get; set; }            
        public string Organisme { get; set; }        

        [Required]
        public DateTime DateObtention { get; set; }       
    }
}
