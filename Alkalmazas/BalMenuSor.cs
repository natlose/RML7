using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.WPF
{
    public class BalMenuSor
    {
        #region Harmonika logika
        public event EventHandler<bool> LathatosagValtozas;

        private bool lathato;
        public bool Lathato
        {
            get => lathato;
            set
            {
                lathato = value;
                if (Kibontott) LathatosagValtozas?.Invoke(this, value);
            }
        }

        public void SzuloLathatosagValtozasakor(object sender, bool e)
        {
            Lathato = e;
        }

        public BalMenuSor SzuloSor { get; set; }

        public bool VanGyermeke { get; set; }

        private bool kibontott;
        public bool Kibontott
        {
            get => kibontott;
            set
            {
                kibontott = value;
            }
        }
        #endregion

        public string Szoveg { get; set; }

        public string FEsetId { get; set; }

        public int BehuzasSzint { get; set; }

        public double BehuzasiSzintSzelesseg { get; set; } = 25d;

        public double BehuzottMargo
        {
            get
            {
                return BehuzasSzint * BehuzasiSzintSzelesseg;
            }
        }


    }
}
