using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Szotar_PostaCim_Tipus : Szotar
    {
        public Szotar_PostaCim_Tipus()
        {
            Add("S", "számlázás");
            Add("L", "levelezés");
            Add("D", "szállítás");
        }
    }
}
