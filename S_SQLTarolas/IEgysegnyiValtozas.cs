using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.SQLTarolas
{
    public interface IEgysegnyiValtozas : IDisposable
    {
        bool VanValtozas();

        void ValtozasRogzitese(Action sikerkor, Action kivetelkor);
    }
}
