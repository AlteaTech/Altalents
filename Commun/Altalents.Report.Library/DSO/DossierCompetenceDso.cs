using System.Collections.Generic;
using System.Linq;

using Altalents.Report.Library.Comparer;

namespace Altalents.Report.Library.DSO
{
    public class DossierCompetenceDso
    {
        public string Trigrame { get; set; }
        public int NumeroDt { get; set; }
        public int NbAnneesExperiences { get; set; } = 10;
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
        public string FormatedSynthese
        {
            get
            {
                return "Spécialisé sur les technologies .NET et JavaScript pouvant intervenir sur plusieurs types de projets :\r\n\r\n- Evolution et maintenance des applications web : clients, web services\r\n- Réduction de la dette technique et amélioration de la qualité du code\r\n- Projets de refonte\r\n- Développement de nouvelles applications\r\n- Analyse et optimisation de performance\r\n- Analyse et amélioration d'architecture applicative\r\n- Analyse, conception UML\r\n- Revue de code et encadrement d’équipe (De 4 à 10 personnes)\r\n- Entretiens techniques, validation de profils et formations\r\n- Spécification techniques\r\n- Développements mobile cross plateforme\r\n- Tests unitaires et mise en place de protocoles de tests\r\n- Administration de bases de données\r\n- Création d’un back office\r\n";
            }
        }
        public List<ExperienceDso> Experiences { get; set; }
        public CommercialDso Commercial { get; set; }
    }
}
