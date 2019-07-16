using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Modul
{
    public class CikkReszletek
    {
        public CikkReszletek(int id, string cikkszam, string nev, string megys)
        {
            Id = id;
            Cikkszam = cikkszam;
            Nev = nev;
            MEgys = megys;
        }

        public int Id { get; }
        public string Cikkszam { get; }
        public string Nev { get; }
        public string MEgys { get; }
    }

}
