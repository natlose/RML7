using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.SQLTarolas
{
    public static class StringMuveletek
    {
        public static void UresbolLegyenNull(ref string s)
        {
            if (String.IsNullOrWhiteSpace(s)) s = null;
        }
    }
}
