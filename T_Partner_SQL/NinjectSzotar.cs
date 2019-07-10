using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class NinjectSzotar : NinjectModule
    {
        public override void Load()
        {
            Bind<IPartnerTarolo>().To<PartnerTarolo_EF>();
        }
    }
}
