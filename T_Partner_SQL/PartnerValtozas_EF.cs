using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PartnerValtozas_EF : Valtozas_EF<PartnerContext>, IPartnerValtozas
    {
        public PartnerValtozas_EF(PartnerContext context)
        {
            this.context = context;
            Partnerek = new PartnerTarolo_EF(context);
        }

        public IPartnerTarolo Partnerek { get; set; }
    }
}
