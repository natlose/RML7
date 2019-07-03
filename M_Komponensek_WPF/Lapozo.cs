using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.WPF
{
    public class Lapozo : Megfigyelheto
    {
        private int sorokszama;
        public int SorokSzama
        {
            get => sorokszama;
            set
            {
                ErtekadasErtesites(ref sorokszama, value);
                Ertesites(nameof(OldalakSzama));
            }
        }

        private int oldalmeret;
        public int Oldalmeret
        {
            get => oldalmeret;
            set
            {
                ErtekadasErtesites(ref oldalmeret, value);
                Ertesites(nameof(OldalakSzama));
            }
        }

        private int oldal;
        public int Oldal
        {
            get => oldal;
            set => ErtekadasErtesites(ref oldal, value);
        }

        public string OldalakSzama
        {
            get
            {
                return oldalmeret != 0 
                    ? SorokSzama != -1 
                        ? Math.Floor((SorokSzama / oldalmeret) + 1d).ToString() 
                        : "?"
                    : "1";
            }
        }

        public void Ujraindit(int sorokSzama = -1)
        {
            SorokSzama = sorokSzama;
            Oldalmeret = 25;
            Oldal = 1;
        }

    }
}
