using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class OrszagTarolo_EF : SQLTarolas.Tarolo_EF<Orszag>, IOrszagTarolo
    {
        public OrszagTarolo_EF(PartnerContext context) : base(context) { }
    }
}
