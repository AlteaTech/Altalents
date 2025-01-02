using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Export.DSO.OpenXml
{
    public class DtExperienceProExportDso
    {

        public bool IsEsn { get; set; }

        public string NomClientIfEsn { get; set; }

        public string NomEntreprise { get; set; }

        public string IntitulePoste { get; set; }

        public string Lieu { get; set; }

        public string TypeContrat { get; set; }

        public string DateDebutEtDateFin { get; set; }

        public string Context { get; set; }

        public string Equipe { get; set; }

        public string EnvironnementsTechnique { get; set; }

        public List<DtExpProMission> MissionsOrProjects { get; set; }


    }
}
