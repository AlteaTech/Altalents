using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class PermissionConsultationDtDto
    {

        public string TokenAccesRapide { get; set; }

        public bool IsValideGuidFromToken { get; set; }

        public bool IsDtExiste { get; set; }

        public bool IsDtAccessible { get; set; }

        public bool IsDtReadOnly { get; set; }

        public bool IsUserLoggedInBackOffice { get; set; }

        public int NumLastEtapeValidated { get; set; }

        public string Message { get; set; }

        public string CodeStatutDT { get; set; }

        public string LibelleStatutDT { get; set; }
    }
}
