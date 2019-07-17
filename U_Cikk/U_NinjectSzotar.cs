﻿using Ninject.Modules;
using Sajat.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class U_NinjectSzotar : NinjectModule
    {
        public override void Load()
        {
            Bind<ICikkReszletezo>().To<CikkReszletezo>();
        }
    }
}