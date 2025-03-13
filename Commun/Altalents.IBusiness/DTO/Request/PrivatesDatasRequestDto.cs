using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.IBusiness.DTO.Request
{
    public class PrivatesDatasRequestDto
    {
        [Required]
        public Guid DtId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Trigramme { get; set; }

        [Required]
        public Guid DisponibiliteId { get; set; }
        public string Poste { get; set; }
        public decimal? TarifJournalier { get; set; }

    }
}
