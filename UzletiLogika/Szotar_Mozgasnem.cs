using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class Szotar_Mozgasnem : Szotar
    {
        public Szotar_Mozgasnem()
        {
            Add("BE", "bevét");
            Add("KI", "eladás");
            Add("ATH", "áthelyezés");
            Add("HNY", "hiány");
            Add("TBL", "többlet");
            Add("SELEJT", "selejtezés");
            Add("FLH", "felhasználás");
        }
    }
}
