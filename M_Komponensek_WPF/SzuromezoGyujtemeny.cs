using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.WPF
{
    public class SzuromezoGyujtemeny : Dictionary<string, Szuromezo>
    {
        public SzuromezoGyujtemeny Mezo(string id, Szuromezo szuromezo)
        {
            Add(id, szuromezo);
            return this;
        }
    }
}
