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
        private event FEKerelemEsemenyKezelo kerelemErkezett;

        private FEKerelemEsemenyKezelo esemenykezelo;

        public FEIndito(FEKerelemEsemenyKezelo esemenykezelo)
        {
            this.esemenykezelo = esemenykezelo;
            kerelemErkezett += esemenykezelo;
        }

        public void Dispose()
        {
            kerelemErkezett -= esemenykezelo;
        }

        public void Inditas(FEKerelem kerelem)
        {
            kerelemErkezett?.Invoke(kerelem);
        }
    }
}
