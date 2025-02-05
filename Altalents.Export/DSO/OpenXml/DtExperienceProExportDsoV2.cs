using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Export.DSO.OpenXml
{
    public class DtExperienceProExportDsoV2
    {

        public bool IsEsn { get; set; }

        public string NomEntreprise { get; set; }

        public string IntitulePoste { get; set; }

        public string Lieu { get; set; }

        public string TypeContrat { get; set; }

        public string DateDebutEtDateFin { get; set; }

        public string DomaineMetier { get; set; }

        public List<DtExpProProjetOrMissionV2> MissionsOrProjects { get; set; }


    }
}
