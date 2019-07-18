using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public static class StringMuveletek
    {
        public static void UresbolLegyenNull(ref string s)
        {
            if (String.IsNullOrWhiteSpace(s)) s = null;
        }

        public static string NullHaUres(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return null;
            else return s;
        }
    }
}
