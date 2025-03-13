using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Altalents.Export.DSO.OpenXml
{
    public class DtExpProProjetOrMissionV2
    {

        public string NomClient { get; set; }
        public string DomaineMetierClient { get; set; }

        public string DateDebutDateFin { get; set; }
        public string Lieu { get; set; }
        public string CompoEquipe { get; set; }

        public string Context { get; set; }

        public string Taches { get; set; }

        public string Competences { get; set; }

        public string Methodologies { get; set; }

        public string EnvironnementsTechnique { get; set; }

    }
}
