using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class FoCsoportTarolo_EF : SQLTarolas.Tarolo_EF<FoCsoport>, IFoCsoportTarolo
    {
        public FoCsoportTarolo_EF(CikkContext context) : base(context)
        {
        }
    }
}
