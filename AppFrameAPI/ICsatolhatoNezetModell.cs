﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkalmazasKeret.API
{
    public interface ICsatolhatoNezetModell
    {
        FEKerelem KapottFEKerelem { get; set; }

        event FEKerelemEsemenyKezelo SajatFEKerelem;
    }
}
