using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO
{
    public class PrivatesDatasDto
    {

        public Guid DtId { get; set; }
        public string Email { get; set; }
        public string Trigramme { get; set; }
        public Guid DisponibiliteId { get; set; }
        public string Poste { get; set; }
        public decimal? TarifJournalier { get; set; }

    }
}
