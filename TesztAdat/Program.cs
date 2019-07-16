using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztAdat
{
    class Program
    {
        static void Main(string[] args)
        {
            var alapertekek = new Dictionary<string, int>() {
                { "FOCSOPORT", 0 },
                { "ALCSOPORT", 00 },
                { "CIKK", 0 },
                { "RAKTAR", 0 },
                { "POLC", 0},
                { "KESZLET", 0 }
            };
            foreach (var p in args.ToDictionary(p => p.ToUpperInvariant().Split('=')[0], p => Int32.Parse(p.Split('=')[1])))
                if (alapertekek.ContainsKey(p.Key)) alapertekek[p.Key] = p.Value;

            var rnd = new Random();

            Console.WriteLine("FoCsoport");
            Sajat.Cikk.Valtozas_EF cikkValtozas = new Sajat.Cikk.Valtozas_EF(new Sajat.Cikk.CikkContext());
            for (int i = 0; i<alapertekek["FOCSOPORT"]; i++)
            {
                cikkValtozas.Tarolo.FoCsoportok.EgyetBetesz( new Sajat.Cikk.FoCsoport() {
                    Nev = Guid.NewGuid().ToString()
                });
            }
            cikkValtozas.ValtozasRogzitese();

            Console.WriteLine("AlCsoport");
            var mindenId = cikkValtozas.Tarolo.FoCsoportok.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["ALCSOPORT"]; i++)
            {
                int veletlen = rnd.Next(mindenId.Count());
                cikkValtozas.Tarolo.AlCsoportok.EgyetBetesz(new Sajat.Cikk.AlCsoport()
                {
                    Nev = Guid.NewGuid().ToString(),
                    FoCsoport = cikkValtozas.Tarolo.FoCsoportok.Egyetlen(mindenId[veletlen])
                }); 
            }
            cikkValtozas.ValtozasRogzitese();

            Console.WriteLine("Cikk");
            var mindenAlCsop = cikkValtozas.Tarolo.AlCsoportok.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["CIKK"]; i++)
            {
                int veletlen = rnd.Next(mindenAlCsop.Count());
                cikkValtozas.Tarolo.Cikkek.EgyetBetesz(new Sajat.Cikk.Cikk()
                {
                    Cikkszam = Guid.NewGuid().ToString(),
                    GyartoiCikkszam = Guid.NewGuid().ToString(),
                    Nev = Guid.NewGuid().ToString(),
                    MEgys = Guid.NewGuid().ToString().Substring(0, 10),
                    AlCsoport = cikkValtozas.Tarolo.AlCsoportok.Egyetlen(mindenAlCsop[veletlen]),
                    
                }); 
            }
            cikkValtozas.ValtozasRogzitese();

            Sajat.Keszlet.Valtozas_EF keszletValtozas = new Sajat.Keszlet.Valtozas_EF(new Sajat.Keszlet.KeszletContext());

            Console.WriteLine("Raktar");
            for (int i = 0; i < alapertekek["RAKTAR"]; i++)
            {
                keszletValtozas.Tarolo.Raktarak.EgyetBetesz(new Sajat.Keszlet.Raktar()
                {
                    Nev = Guid.NewGuid().ToString().Substring(0, 30)
                }); ;
            }
            keszletValtozas.ValtozasRogzitese();

            Console.WriteLine("Polc");
            var mindenRaktar = keszletValtozas.Tarolo.Raktarak.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["POLC"]; i++)
            {
                int veletlen = rnd.Next(mindenRaktar.Count());
                keszletValtozas.Tarolo.Polcok.EgyetBetesz(new Sajat.Keszlet.Polc()
                {
                    Kod = Guid.NewGuid().ToString().Substring(0, 15),
                    Megjegyzes = Guid.NewGuid().ToString(),
                    Raktar = keszletValtozas.Tarolo.Raktarak.Egyetlen(mindenRaktar[veletlen])
                });
            }
            keszletValtozas.ValtozasRogzitese();

            Console.WriteLine("Keszlet");
            var mindenPolc = keszletValtozas.Tarolo.Polcok.Mind().Select(e => e.Id).ToArray();
            var mindenCikk = cikkValtozas.Tarolo.Cikkek.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["KESZLET"]; i++)
            {
                int veletlenPolc = rnd.Next(mindenPolc.Count());
                int veletlenCikk = rnd.Next(mindenCikk.Count());
                keszletValtozas.Tarolo.Keszletek.EgyetBetesz(new Sajat.Keszlet.Keszlet()
                {
                    Polc = keszletValtozas.Tarolo.Polcok.Egyetlen(mindenPolc[veletlenPolc]),
                    CikkID = mindenCikk[veletlenCikk],
                    Meny = rnd.Next(100)
                });
                keszletValtozas.ValtozasRogzitese();
            }


        }
    }
}
