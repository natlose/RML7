using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Valtozas_EF : IValtozas
    {
        private readonly EFContext context;

        public Valtozas_EF(EFContext context)
        {
            this.context = context;
            Partnerek = new Tarolo_EF(context);
        }

        public ITarolo Partnerek { get; set; }

        public int ValtozasVege()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
