﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.API
{
    public class FEParameterek : Dictionary<string, object>
    {
        public FEParameterek() { }

        public FEParameterek Parameter(string kulcs, object ertek)
        {
            Add(kulcs, ertek);
            return this;
        }

        public T As<T>(string kulcs, Action<string> kivetelkor = null)
        {
            try
            {
                return (T)this[kulcs];
            }
            catch (Exception e)
            {
                if (kivetelkor != null) kivetelkor.Invoke(kulcs + ":\n" + e.Message);
                return default;
            }
        }
    }
}
