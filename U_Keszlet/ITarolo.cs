using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public interface ITarolo
    {
        ITarolo<Raktar> Raktarak { get; }

        ITarolo<Polc> Polcok { get; }

        ITarolo<Keszlet> Keszletek { get; }
    }
}
