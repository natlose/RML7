﻿using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public interface IAlCsoportValtozas : IEgysegnyiValtozas
    {
        IAlCsoportTarolo AlCsoportok { get; set; }
    }
}