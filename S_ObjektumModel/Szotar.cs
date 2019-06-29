using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public class Szotar : Dictionary<string, string>
    {
        public List<KeyValuePair<string, string>> Bejegyzesek
        {
            get => this.ToList();
        }
    }
}
