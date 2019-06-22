using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFrame.API
{
    public class FEEredmenyek : Dictionary<string, object> {  }

    public delegate void FEEredmenyekEsemenyKezelo(IDinamikusanCsatolhatoNezetModell kuldte, FEEredmenyek eredmenyek);
}
