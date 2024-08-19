using System;
using System.Collections.Generic;

using Telerik.Reporting;

namespace Altalents.Report.Library.DSO
{
    public class ExperienceDso
    {
        public string IntitulePoste { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public List<ConnaissanceDso> Technologies { get; set; } = new List<ConnaissanceDso>();
        public List<ConnaissanceDso> Methodologies { get; set; } = new List<ConnaissanceDso>();
        public List<ConnaissanceDso> Competences { get; set; } = new List<ConnaissanceDso>();

        public List<ConnaissanceDso> AllConnaissances
        {
            get
            {
                List<ConnaissanceDso> retour = new List<ConnaissanceDso>();
                retour.AddRange(Technologies);
                retour.AddRange(Methodologies);
                retour.AddRange(Competences);
                return retour;
            }
        }
    }
}
