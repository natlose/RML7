using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class NinjectSzotar : NinjectModule
    {
        public override void Load()
        {
            Bind<ITarolo>().To<Tarolo_EF>();
            Bind<IValtozas>().To<Valtozas_EF>();
        }
    }
}
