﻿using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public interface IOrszagValtozas : IEgysegnyiValtozas
    {
        IOrszagTarolo Orszagok { get; set; }
    }
}