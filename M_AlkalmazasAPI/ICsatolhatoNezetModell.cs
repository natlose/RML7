using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.API
{
    public interface ICsatolhatoNezetModell
    {
        FEKerelem KapottFEKerelem { get; set; }

        event FEKerelemEsemenyKezelo SajatFEKerelem;

        bool Megszakithato { get; }
    }
}
