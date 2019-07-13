using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.API
{
    public delegate void FEKerelemEsemenyKezelo(FEKerelem kerelem);

    public class FEIndito : IDisposable
    {
        private event FEKerelemEsemenyKezelo SajatFEKerelem;

        private FEKerelemEsemenyKezelo esemenykezelo;

        public FEIndito(FEKerelemEsemenyKezelo esemenykezelo)
        {
            this.esemenykezelo = esemenykezelo;
            SajatFEKerelem += esemenykezelo;
        }

        public void Dispose()
        {
            SajatFEKerelem -= esemenykezelo;
        }

        public void Inditas(FEKerelem kerelem)
        {
            SajatFEKerelem?.Invoke(kerelem);
        }
    }
}
