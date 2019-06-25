using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Valtozas_EF : IEgysegnyiValtozas
    {
        private readonly EFContext context;

        public Valtozas_EF(EFContext context)
        {
            this.context = context;
            Partnerek = new Tarolo_EF(context);
        }

        public ITarolo Partnerek { get; set; }

        #region IEgysegnyiValtozas
        public bool VanValtozas()
        {
            return context.ChangeTracker.HasChanges();
        }

        public int ValtozasRogzitese()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion

    }
}
