using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altalents.Entities
{

    public partial class Projet : BaseEntity
    {

        public Projet()
        { }

        public string Nom { get; set; }

        public string Description { get; set; }

        public string Taches { get; set; }

        public Experience Experience { get; set; }

    }
}
