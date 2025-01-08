using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.Commun.Enums;

namespace Altalents.IBusiness.DTO
{
    public class FormationCertificationDto
    {

        [Required]
        public Guid Id { get; set; }             
        public string Libelle { get; set; }        
        public string Niveau { get; set; }           
        public string Organisme { get; set; }       
        public DateTime DateDebut { get; set; }      
        public DateTime? DateFin { get; set; }

    }
}
