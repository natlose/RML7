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
            Bind<IPartnerValtozas>().To<PartnerValtozas_EF>();
            Bind<IOrszagTarolo>().To<OrszagTarolo_EF>();
            Bind<IOrszagValtozas>().To<OrszagValtozas_EF>();
            Bind<IIrszamTarolo>().To<IrszamTarolo_EF>();
            Bind<IIrszamValtozas>().To<IrszamValtozas_EF>();
        }
    }
}
