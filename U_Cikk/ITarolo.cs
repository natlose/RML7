using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public interface ITarolo
    {
        ITarolo<FoCsoport> FoCsoportok { get; }

        ITarolo<AlCsoport> AlCsoportok { get; }

        ITarolo<Cikk> Cikkek { get; }
    }
}
