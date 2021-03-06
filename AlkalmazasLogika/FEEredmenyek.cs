﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.API
{
    public class FEEredmenyek : Dictionary<string, object>
    {

        public FEEredmenyek(){ }

        public FEEredmenyek Eredmeny(string kulcs, object ertek)
        {
            Add(kulcs, ertek);
            return this;
        }

        public T As<T>(string kulcs)
        {
            try
            {
                return (T)this[kulcs];
            }
            catch (Exception e)
            {
                throw new InvalidCastException(kulcs + ":\n" + e.Message);
            }
        }
    }

    public delegate void FEEredmenyekEsemenyKezelo(ICsatolhatoNezetModell kuldte, FEEredmenyek eredmenyek);
}
