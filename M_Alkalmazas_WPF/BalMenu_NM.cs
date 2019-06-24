using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Alkalmazas.WPF
{
    public class BalMenu_NM : Megfigyelheto
    {

        public ObservableCollection<BalMenuSor> LathatoSorok { get; private set; } = new ObservableCollection<BalMenuSor>();

        public List<BalMenuSor> MindenSor { get; private set; } = new List<BalMenuSor>();

        private BalMenuSor kivalasztottSor;
        public BalMenuSor KivalasztottSor
        {
            get { return kivalasztottSor; }
            set
            {
                kivalasztottSor = value;
                MegfigyelokErtesitese(nameof(KivalasztottSor));
            }
        }


        private void rekurzivGyermekElemErtelmezes(XElement szuloElem, int behuzasSzint, BalMenuSor szuloSor)
        {
            IEnumerable<XElement> gyermekElemek = szuloElem.Elements();
            if (gyermekElemek.Count() > 0)
            {
                if (szuloSor != null) szuloSor.VanGyermeke = true;
                foreach (var gyermekElem in gyermekElemek)
                {
                    BalMenuSor gyermekSor = new BalMenuSor
                    {
                        SzuloSor = szuloSor,
                        Szoveg = gyermekElem.Attribute("szoveg")?.Value,
                        SzerelvenyNeve = gyermekElem.Attribute("szerelveny")?.Value,
                        OsztalyNeve = gyermekElem.Attribute("osztaly")?.Value,
                        BehuzasSzint = behuzasSzint
                    };
                    if (szuloSor != null) szuloSor.LathatosagValtozas += gyermekSor.SzuloLathatosagValtozasakor;
                    MindenSor.Add(gyermekSor);
                    rekurzivGyermekElemErtelmezes(gyermekElem, behuzasSzint + 1, gyermekSor);
                }
            }
        }

        private void lathatoSorokUjrageneralasa()
        {
            BalMenuSor kvsor = KivalasztottSor;
            LathatoSorok.Clear();
            foreach (var sor in MindenSor.Where(i => i.Lathato).ToList()) LathatoSorok.Add(sor);
            KivalasztottSor = kvsor;            
        }

        public void FeluletBetoltesenekBefejezesekor()
        {
            try
            {
                rekurzivGyermekElemErtelmezes(XElement.Load(Path.Combine(Directory.GetCurrentDirectory(), "M_Alkalmazas_WPF_BalMenu.xml")), 0, null);
                foreach (var sor in MindenSor.Where(i => i.SzuloSor == null)) sor.Lathato = true;
                lathatoSorokUjrageneralasa();
            }
            catch (Exception) { }
        }

        private void kibontottsagValtasa(BalMenuSor sor, bool ujAllapot)
        {
            foreach (var gyermek in MindenSor.Where(i => i.SzuloSor == sor)) gyermek.Lathato = ujAllapot;
            sor.Kibontott = ujAllapot;
        }

        public event EventHandler<FEKerelem> UjTortenetKerelem;

        public void SorKivalasztasakor(BalMenuSor sor)
        {
            if (sor.VanGyermeke)
            {
                foreach (var testver in MindenSor.Where(i => i.SzuloSor == sor.SzuloSor)) kibontottsagValtasa(testver, false);
                kibontottsagValtasa(sor, !sor.Kibontott);
                lathatoSorokUjrageneralasa();
            }
            else
            {
                UjTortenetKerelem?.Invoke(this, new FEKerelem(sor.SzerelvenyNeve, sor.OsztalyNeve));
            }
        }


    }
}
