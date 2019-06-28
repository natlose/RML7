using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public interface IEgysegnyiValtozas : IDisposable
    {
        bool VanValtozas { get; }

        bool VanUtkozes { get; }

        bool VanErvenytelenAdat { get; }

        bool ValtozasRogzitese();
    }
}
