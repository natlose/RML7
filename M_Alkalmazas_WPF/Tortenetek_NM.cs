using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Ninject;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Alkalmazas.WPF
{
    public class Tortenetek_NM : Megfigyelheto
    {
        public ObservableCollection<Tortenet> Tortenetek { get; set; } = new ObservableCollection<Tortenet>();

        private Regiszter regiszter = new Regiszter(Path.Combine(Directory.GetCurrentDirectory(), "M_Alkalmazas_WPF_FEsetek.xml"));

        private static string[] KonfiguraltModulok(string konfigFajlUtvonal)
        {
            List<string> eredmeny = new List<string>();
            try
            {
                foreach (var elem in XElement.Load(konfigFajlUtvonal).Elements())
                {
                    if (elem.Name.LocalName == "Modul")
                    {
                        string nev = elem.Attribute("nev")?.Value;
                        if (String.IsNullOrEmpty(nev)) throw new ArgumentNullException("A 'nev' attribútum hiányzik");
                        eredmeny.Add(nev);
                    }
                }
                return eredmeny.ToArray();
            }
            catch (Exception)
            {
                //todo: hibakezelés kéne
                throw;
            }
        }

        private IKernel ninjectKernel = new StandardKernel(
            new NinjectSettings()
            {
                ExtensionSearchPatterns = KonfiguraltModulok(Path.Combine(Directory.GetCurrentDirectory(), "M_Alkalmazas_WPF_Modulok.xml")),
                LoadExtensions = true
            }
        );

        private DateTime aktiv;
        public DateTime Aktiv
        {
            get => aktiv;
            set
            {
                ErtekadasErtesites(ref aktiv, value);
                // Hogy tudja a történet is magáról, hogy ő az aktív:
                foreach (var t in Tortenetek) t.AktivVagyok = false;
                if (AktivTortenet != null) AktivTortenet.AktivVagyok = true; // Igy meg tudja változtatni a küllemét.
                Ertesites(nameof(AktivTortenet));
            }
        }

        public Tortenet AktivTortenet
        {
            get => Tortenetek.SingleOrDefault(t => t.Azonosito == aktiv);
        }
        public bool FoAblakBezarhato
        {
            get
            {
                //Ha bármelyik nézetmodell azt mondja, hogy nem megszakítható, akkor a főablak nem zárható be:
                return !Tortenetek.SelectMany(t => t.FEsetek).Any(fe => !fe.NezetModell.Megszakithato);
            }
        }

        public void UjTortenetKerelemkor(object sender, FEKerelem kerelem)
        {
            Tortenet tortenet = new Tortenet(
                kerelem, 
                (t) => 
                {
                    TortenetValtozott?.Invoke(t, null);
                    // Ha kiürült a történet, akkor kidobom a listából is:
                    if (t.FEsetek.Count == 0)
                    {
                        Aktiv = DateTime.MinValue;
                        Tortenetek.Remove(t);
                    }
                },
                (id) => regiszter.Felismeres(id),
                ninjectKernel
                );
            Tortenetek.Add(tortenet);
            Aktiv = tortenet.Azonosito;
        }

        public event EventHandler TortenetValtozott;

    }
}
