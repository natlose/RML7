using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public interface IValtozas :  IEgysegnyiValtozas
    {
        ITarolok Tarolok { get; }
    }
}
