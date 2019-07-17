using Sajat.Tarolas;
using Sajat.Uzlet;
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
            Valtozas_EF valtozas = new Valtozas_EF(new SajatContext());

            Console.WriteLine("FoCsoport");
            for (int i = 0; i<alapertekek["FOCSOPORT"]; i++)
            {
                valtozas.Tarolok.FoCsoportok.EgyetBetesz( new FoCsoport() {
                    Nev = Guid.NewGuid().ToString()
                });
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("AlCsoport");
            var mindenId = valtozas.Tarolok.FoCsoportok.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["ALCSOPORT"]; i++)
            {
                int veletlen = rnd.Next(mindenId.Count());
                valtozas.Tarolok.AlCsoportok.EgyetBetesz(new AlCsoport()
                {
                    Nev = Guid.NewGuid().ToString(),
                    FoCsoport = valtozas.Tarolok.FoCsoportok.Egyetlen(mindenId[veletlen])
                }); 
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Cikk");
            var mindenAlCsop = valtozas.Tarolok.AlCsoportok.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["CIKK"]; i++)
            {
                int veletlen = rnd.Next(mindenAlCsop.Count());
                valtozas.Tarolok.Cikkek.EgyetBetesz(new Cikk()
                {
                    Cikkszam = Guid.NewGuid().ToString(),
                    GyartoiCikkszam = Guid.NewGuid().ToString(),
                    Nev = Guid.NewGuid().ToString(),
                    MEgys = Guid.NewGuid().ToString().Substring(0, 10),
                    AlCsoport = valtozas.Tarolok.AlCsoportok.Egyetlen(mindenAlCsop[veletlen]),
                    
                }); 
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Raktar");
            for (int i = 0; i < alapertekek["RAKTAR"]; i++)
            {
                valtozas.Tarolok.Raktarak.EgyetBetesz(new Raktar()
                {
                    Nev = Guid.NewGuid().ToString().Substring(0, 30)
                }); ;
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Polc");
            var mindenRaktar = valtozas.Tarolok.Raktarak.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["POLC"]; i++)
            {
                int veletlen = rnd.Next(mindenRaktar.Count());
                valtozas.Tarolok.Polcok.EgyetBetesz(new Polc()
                {
                    Kod = Guid.NewGuid().ToString().Substring(0, 15),
                    Megjegyzes = Guid.NewGuid().ToString(),
                    Raktar = valtozas.Tarolok.Raktarak.Egyetlen(mindenRaktar[veletlen])
                });
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Keszlet");
            var mindenPolc = valtozas.Tarolok.Polcok.Mind().Select(e => e.Id).ToArray();
            var mindenCikk = valtozas.Tarolok.Cikkek.Mind().Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["KESZLET"]; i++)
            {
                int veletlenPolc = rnd.Next(mindenPolc.Count());
                int veletlenCikk = rnd.Next(mindenCikk.Count());
                valtozas.Tarolok.Keszletek.EgyetBetesz(new Keszlet()
                {
                    Polc = valtozas.Tarolok.Polcok.Egyetlen(mindenPolc[veletlenPolc]),
                    Cikk = valtozas.Tarolok.Cikkek.Egyetlen(mindenCikk[veletlenCikk]),
                    Meny = rnd.Next(100)
                });
                valtozas.ValtozasRogzitese();
            }


        }
    }
}
