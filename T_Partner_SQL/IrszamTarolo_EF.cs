using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class IrszamTarolo_EF : SQLTarolas.Tarolo_EF<Irszam>, IIrszamTarolo
    {
        public IrszamTarolo_EF(PartnerContext context) : base(context) { }
    }
}
