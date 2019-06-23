using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkalmazasKeret.API
{
    public class FEEredmenyek : Dictionary<string, object> {  }

    public delegate void FEEredmenyekEsemenyKezelo(ICsatolhatoNezetModell kuldte, FEEredmenyek eredmenyek);
}
