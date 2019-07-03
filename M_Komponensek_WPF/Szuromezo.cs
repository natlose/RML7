using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.WPF
{
    public class Szuromezo : Megfigyelheto
    {
        public Szuromezo(string nev, Action<Szuromezo> kereseskor = null)
        {
            Nev = nev;
            Kereseskor = kereseskor;
        }

        public string Nev { get; private set; }

        private string ertek;
        public string Ertek
        {
            get => ertek;
            set => ErtekadasErtesites(ref ertek, value);
        }

        public Action<Szuromezo> Kereseskor { get; set; }
    }
}
