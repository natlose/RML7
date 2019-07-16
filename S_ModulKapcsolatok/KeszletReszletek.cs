using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Modul
{
    public class KeszletReszletek
    {
        public KeszletReszletek(int RaktarId, string RaktarNev, int PolcId, string PolcKod, int CikkId, decimal Keszlet)
        {
            this.RaktarId = RaktarId;
            this.RaktarNev = RaktarNev;
            this.PolcId = PolcId;
            this.PolcKod = PolcKod;
            this.CikkId = CikkId;
            this.Keszlet = Keszlet;
        }

        public int RaktarId { get; }
        public string RaktarNev { get; }
        public int PolcId { get; }
        public string PolcKod { get; }
        public int CikkId { get; }
        public decimal Keszlet { get; }
    }
}
