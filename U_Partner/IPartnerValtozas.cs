﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public interface IPartnerValtozas : ObjektumModel.IEgysegnyiValtozas
    {
        IPartnerTarolo Partnerek { get; set; }
    }
}