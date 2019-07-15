using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public interface IValtozas :  IEgysegnyiValtozas
    {
        ITarolo Tarolo { get; }
    }
}
