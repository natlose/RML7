using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public enum RogzitesEredmeny
    {
        Nincs = 0,
        Siker = 1,
        Versenyhelyzet = -1,
        ErvenytelenAdat = -2,
        NemTarolhato = -3  // pl. másodlagos kulcsok egyediségének megsértése
    }
}
