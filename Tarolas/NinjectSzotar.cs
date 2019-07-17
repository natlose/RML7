using Ninject.Modules;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class NinjectSzotar : NinjectModule
    {
        public override void Load()
        {
            Bind<ITarolok>().To<Tarolok_EF>();
            Bind<IValtozas>().To<Valtozas_EF>();
        }
    }
}
