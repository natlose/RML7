using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public interface ITarolo : SQLTarolas.ITarolo<Partner>
    {
        IEnumerable<Partner> NevAlapjan(string nev, int oldal, int oldalmeret);
    }
}
