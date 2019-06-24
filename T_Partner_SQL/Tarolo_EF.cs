using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Tarolo_EF : SQLTarolas.Tarolo_EF<Partner>, ITarolo
    {
        public Tarolo_EF(EFContext context) : base(context) { }

        public IEnumerable<Partner> NevAlapjan(string nev, int oldal, int oldalmeret)
        {
            return (context as EFContext).Partnerek
                .Where(p => (p.Maganszemely.Vezeteknev + p.Maganszemely.Keresztnev).Contains(nev))
                .OrderBy(p => p.Maganszemely.Vezeteknev + p.Maganszemely.Keresztnev)
                .Skip((oldal - 1) * oldalmeret)
                .Take(oldalmeret)
                .ToList();
        }
    }
}
