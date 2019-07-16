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
        public CikkReszletezo(ITarolo tarolo)
        {
            this.tarolo = tarolo;
        }

        private ITarolo tarolo;

        public CikkReszletek[] Reszletezes(int[] azonositok)
        {
            Cikk[] cikkek = tarolo.Cikkek.MindAhol(c => azonositok.Contains(c.Id)).ToArray();
            var result = azonositok.Zip(cikkek, 
                (azonosito, cikk) => 
                {
                    return new CikkReszletek() { Id = azonosito, Cikkszam = cikk.Cikkszam, Nev = cikk.Nev, MEgys = cikk.MEgys };
                } 
            );
            return result.ToArray();
        }
    }
}
