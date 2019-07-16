using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Modul
{
    public interface IKeszletReszletezo
    {
        IEnumerable<KeszletReszletek> Reszletezes(IEnumerable<int> cikkAzonositok);

    }
}
