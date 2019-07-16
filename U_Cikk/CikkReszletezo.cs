using Sajat.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{

    public class CikkReszletezo : ICikkReszletezo
    {
        private readonly ITarolo tarolo;

        public CikkReszletezo(ITarolo tarolo)
        {
            this.tarolo = tarolo;
        }

        public IEnumerable<CikkReszletek> Reszletezes(IEnumerable<int> azonositok)
        {
            IEnumerable<Cikk> cikkek = tarolo.Cikkek.MindAhol(c => azonositok.Contains(c.Id)).ToList();
            var result = azonositok.Zip(cikkek, 
                (azonosito, cikk) => 
                {
                    return new CikkReszletek(azonosito, cikk.Cikkszam, cikk.Nev, cikk.MEgys);
                } 
            );
            return result.ToList();
        }
    }
}
