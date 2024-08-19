using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Report.Library.DSO
{
    public class DossierCompetenceDso
    {
        public string Trigrame { get; set; }
        public int NumeroDt { get; set; }
        public string Poste { get; set; }
        public List<ExperienceDso> Experiences { get; set; }
    }
}
