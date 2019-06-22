﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFrame.API
{
    public interface IDinamikusanCsatolhatoNezetModell
    {
        FEKerelem KapottFEKerelem { get; set; }

        event FEKerelemEsemenyKezelo SajatFEKerelem;
    }
}
