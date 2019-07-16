using Sajat.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class KeszletReszletezo : IKeszletReszletezo
    {
        private readonly ITarolo tarolo;

        public KeszletReszletezo(ITarolo tarolo)
        {
            this.tarolo = tarolo;
        }

        public IEnumerable<KeszletReszletek> Reszletezes(IEnumerable<int> cikkAzonositok)
        {
            IEnumerable<Keszlet> keszletek = tarolo.Keszletek.KiterjesztettMindAhol(
                k => cikkAzonositok.Contains(k.CikkID),
                k => k.Polc,
                k => k.Polc.Raktar
            ).ToList();
            var result = cikkAzonositok.Zip(
                keszletek,
                (azonosito, keszlet) => new KeszletReszletek(
                    keszlet.Polc.Raktar.Id,
                    keszlet.Polc.Raktar.Nev,
                    keszlet.Polc.Id,
                    keszlet.Polc.Kod,
                    keszlet.CikkID,
                    keszlet.Meny
                )
            );
            return result.ToList();
        }
    }
}
