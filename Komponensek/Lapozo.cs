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
        // -1 : ismeretlen
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

        // 0 : nincs lapozás, teljes eredmény lehívandó
        private int oldalmeret = 20;
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

        public void Ujraindit(int sorokSzama = -1, int oldalmeret = 20)
        {
            SorokSzama = sorokSzama;
            Oldalmeret = oldalmeret;
            Oldal = 1;
        }

    }
}
