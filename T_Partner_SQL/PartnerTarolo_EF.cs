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

        public IEnumerable<Partner> NevAlapjan(string nev, int oldal, int oldalmeret)
        {
            return (context as PartnerContext).Partnerek
                .Where(p => (p.Maganszemely.Vezeteknev + p.Maganszemely.Keresztnev).Contains(nev))
                .OrderBy(p => p.Maganszemely.Vezeteknev + p.Maganszemely.Keresztnev)
                .Skip((oldal - 1) * oldalmeret)
                .Take(oldalmeret)
                .ToList();
        }
    }
}
