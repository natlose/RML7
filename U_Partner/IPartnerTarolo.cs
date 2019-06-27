using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public interface IPartnerTarolo : ITarolo<Partner>
    {
        IEnumerable<Partner> NevAlapjan(string nev, int oldal, int oldalmeret);
    }
}
