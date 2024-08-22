using System.Collections.Generic;

using Altalents.Report.Library.DSO;

namespace Altalents.Report.Library.Comparer
{
    internal class ConnaissanceDsoComparer : IEqualityComparer<ConnaissanceDso>
    {
        public bool Equals(ConnaissanceDso x, ConnaissanceDso y)
        {
            return x.Libelle == y.Libelle;
        }

        public int GetHashCode(ConnaissanceDso obj)
        {
            return 0;
        }
    }
}
