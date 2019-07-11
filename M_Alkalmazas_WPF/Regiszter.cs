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
        public string NezetOsztaly { get; set; }
        public string NezetModellOsztaly { get; set; }
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
                        string nezet = elem.Attribute("n")?.Value;
                        if (String.IsNullOrEmpty(nezet)) throw new ArgumentNullException("Az 'n' attribútum hiányzik");
                        string nezetmodell = elem.Attribute("nm")?.Value;
                        if (String.IsNullOrEmpty(nezetmodell)) throw new ArgumentNullException("Az 'nm' attribútum hiányzik");
                        nezetek.Add(id, new RegiszterBejegyzes() { NezetOsztaly = nezet, NezetModellOsztaly = nezetmodell });
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
