using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sajat.Partner
{
    public class IrszamValtozas_EF : Valtozas_EF<PartnerContext>, IIrszamValtozas
    {
        public IrszamValtozas_EF(PartnerContext context)
        {
            this.context = context;
            Irszamok = new IrszamTarolo_EF(context);
        }

        public IIrszamTarolo Irszamok { get; set; }
    }
}