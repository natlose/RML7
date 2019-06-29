using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class OrszagValtozas_EF : Valtozas_EF<PartnerContext>, IOrszagValtozas
    {
        public OrszagValtozas_EF(PartnerContext context)
        {
            this.context = context;
            Orszagok = new OrszagTarolo_EF(context);
        }

        public IOrszagTarolo Orszagok { get; set; }
    }
}
