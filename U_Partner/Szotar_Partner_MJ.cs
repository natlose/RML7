﻿using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Szotar_Partner_MJ : Szotar
    {
        public Szotar_Partner_MJ()
        {
            this.Add("M", "magánszemély");
            this.Add("J", "jogiszemély");
        }
    }
}
