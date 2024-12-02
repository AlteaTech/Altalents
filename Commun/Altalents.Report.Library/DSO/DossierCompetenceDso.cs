using System.Collections.Generic;
using System.Linq;
using System.Web;
using Altalents.Report.Library.Comparer;

namespace Altalents.Report.Library.DSO
{
    public class DossierCompetenceDso
    {
        public string Trigrame { get; set; }
        public int NumeroDt { get; set; }
        public int NbAnneesExperiences { get; set; }
        public string Poste { get; set; }
        public string FormatedCompetencesClefs
        {
            get
            {

                List<ConnaissanceDso> retour = new List<ConnaissanceDso>();
                retour.AddRange(Experiences.SelectMany(x => x.AllConnaissances));
                retour = retour.OrderByDescending(x => x.Niveau)
                    .ThenBy(x => x.Libelle)
                    .Distinct(new ConnaissanceDsoComparer())
                    .Take(5)
                    .ToList();
                return string.Join(", ", retour.Select(x => x.Libelle));            }
        }
        public string FormatedSynthese { get; set; }


        public List<ExperienceDso> Experiences { get; set; }
        public CommercialDso Commercial { get; set; }
    }
}
