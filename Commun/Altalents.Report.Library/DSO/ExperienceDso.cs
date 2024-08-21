using System;
using System.Collections.Generic;
using System.Linq;

using Telerik.Reporting;

namespace Altalents.Report.Library.DSO
{
    public class ExperienceDso
    {
        public string IntitulePoste { get; set; }
        public string Entreprise { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public List<ConnaissanceDso> Technologies { get; set; } = new List<ConnaissanceDso>();
        public List<ConnaissanceDso> Methodologies { get; set; } = new List<ConnaissanceDso>();
        public List<ConnaissanceDso> Competences { get; set; } = new List<ConnaissanceDso>();

        public string PlageExperience
        {
            get
            {
                if (!DateFin.HasValue)
                {
                    return $"Depuis {DateDebut.ToString("MMMM yyyy")}";
                }
                return $"De {DateDebut.ToString("MMMM yyyy")} à {DateFin.Value.ToString("MMMM yyyy")}";
            }
        }

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
        public string FormatedEnvironnement
        {
            get
            {

                List<ConnaissanceDso> retour = new List<ConnaissanceDso>();
                retour.AddRange(AllConnaissances);
                retour = retour.OrderByDescending(x => x.Niveau)
                    .ThenBy(x => x.Libelle)
                    .ToList();
                return string.Join(", ", retour.Select(x => x.Libelle));
            }
        }
    }
}
