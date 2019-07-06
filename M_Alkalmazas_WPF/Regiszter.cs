using Sajat.Alkalmazas.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sajat.Alkalmazas.WPF
{
    public class RegiszterBejegyzes
    {
        public string Szerelveny { get; set; }
        public string Osztaly { get; set; }
    }

    public class Regiszter
    {
        public Regiszter(string utvonal)
        {
            Betoltes(utvonal);
        }

        private Dictionary<string, RegiszterBejegyzes> nezetek = new Dictionary<string, RegiszterBejegyzes>();

        private void Betoltes(string utvonal)
        {
            try
            {
                foreach (var elem in XElement.Load(utvonal).Elements())
                {
                    if (elem.Name.LocalName == "FEset")
                    {
                        string id = elem.Attribute("id")?.Value;
                        if (String.IsNullOrEmpty(id)) throw new ArgumentNullException("Az 'id' attribútum hiányzik");
                        string szerelveny = elem.Attribute("szerelveny")?.Value;
                        if (String.IsNullOrEmpty(id)) throw new ArgumentNullException("A 'szerelveny' attribútum hiányzik");
                        string osztaly = elem.Attribute("osztaly")?.Value;
                        if (String.IsNullOrEmpty(id)) throw new ArgumentNullException("Az 'osztaly' attribútum hiányzik");
                        nezetek.Add(id, new RegiszterBejegyzes() { Szerelveny = szerelveny, Osztaly = osztaly });
                    }
                }
            }
            catch (Exception)
            {
                //todo: hibakezelés kéne
                throw;
            }
        }

        public RegiszterBejegyzes Felismeres(string id)
        {
            if (nezetek.ContainsKey(id)) return nezetek[id];
            else return null;
        }
    }
}
