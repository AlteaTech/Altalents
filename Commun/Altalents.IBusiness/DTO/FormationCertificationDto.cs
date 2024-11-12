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
        public Guid Id { get; set; }                // Id de la formation / Certification
        public string Libelle { get; set; }          // Nom de la formation / Certification
        public string Domaine { get; set; }           // Domaine de la formation / Certification (ex: Node JS)
        public string Niveau { get; set; }            // Niveau (ex: Bac)
        public string Organisme { get; set; }         // Organisme responsable de la formation / Certification
        public DateTime DateDebut { get; set; }       // Date de début de la formation / Certification
        public DateTime? DateFin { get; set; }        // Date de fin de la formation / Certification (peut être null si en cours)
    }




}
