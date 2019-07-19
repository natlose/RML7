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
            Valtozas valtozas = new Valtozas(new SajatContext());

            Console.WriteLine("FoCsoport");
            for (int i = 0; i<alapertekek["FOCSOPORT"]; i++)
            {
                valtozas.Context.FoCsoportok.Add( new FoCsoport() {
                    Nev = Guid.NewGuid().ToString()
                });
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("AlCsoport");
            var mindenId = valtozas.Context.FoCsoportok.Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["ALCSOPORT"]; i++)
            {
                int veletlen = rnd.Next(mindenId.Count());
                valtozas.Context.AlCsoportok.Add(new AlCsoport()
                {
                    Nev = Guid.NewGuid().ToString(),
                    FoCsoport = valtozas.Context.FoCsoportok.Single(f => f.Id == mindenId[veletlen])
                }); 
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Cikk");
            var mindenAlCsop = valtozas.Context.AlCsoportok.Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["CIKK"]; i++)
            {
                int veletlen = rnd.Next(mindenAlCsop.Count());
                valtozas.Context.Cikkek.Add(new Cikk()
                {
                    Cikkszam = Guid.NewGuid().ToString(),
                    GyartoiCikkszam = Guid.NewGuid().ToString(),
                    Nev = Guid.NewGuid().ToString(),
                    MEgys = Guid.NewGuid().ToString().Substring(0, 10),
                    AlCsoport = valtozas.Context.AlCsoportok.Single(a => a.Id == mindenAlCsop[veletlen]),
                    
                }); 
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Raktar");
            for (int i = 0; i < alapertekek["RAKTAR"]; i++)
            {
                valtozas.Context.Raktarak.Add(new Raktar()
                {
                    Nev = Guid.NewGuid().ToString().Substring(0, 30)
                }); ;
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Polc");
            var mindenRaktar = valtozas.Context.Raktarak.Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["POLC"]; i++)
            {
                int veletlen = rnd.Next(mindenRaktar.Count());
                valtozas.Context.Polcok.Add(new Polc()
                {
                    Kod = Guid.NewGuid().ToString().Substring(0, 15),
                    Megjegyzes = Guid.NewGuid().ToString(),
                    Raktar = valtozas.Context.Raktarak.Single(r => r.Id == mindenRaktar[veletlen])
                });
            }
            valtozas.ValtozasRogzitese();

            Console.WriteLine("Keszlet");
            var mindenPolc = valtozas.Context.Polcok.Select(e => e.Id).ToArray();
            var mindenCikk = valtozas.Context.Cikkek.Select(e => e.Id).ToArray();
            for (int i = 0; i < alapertekek["KESZLET"]; i++)
            {
                int veletlenPolc = rnd.Next(mindenPolc.Count());
                int veletlenCikk = rnd.Next(mindenCikk.Count());
                valtozas.Context.Keszletek.Add(new Keszlet()
                {
                    Polc = valtozas.Context.Polcok.Single(p => p.Id == mindenPolc[veletlenPolc]),
                    Cikk = valtozas.Context.Cikkek.Single(c => c.Id == mindenCikk[veletlenCikk]),
                    Meny = rnd.Next(100)
                });
                valtozas.ValtozasRogzitese();
            }


        }
    }
}
