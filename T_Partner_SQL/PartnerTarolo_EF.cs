using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PartnerTarolo_EF : SQLTarolas.Tarolo_EF<Partner>, IPartnerTarolo
    {
        public PartnerTarolo_EF(PartnerContext context) : base(context) { }

        public Partner EgyetlenEsPostaCimek(int id)
        {
            return (context as PartnerContext).Partnerek.Include(p => p.PostaCimek).Single(p => p.Id == id);
        }
    }
}
