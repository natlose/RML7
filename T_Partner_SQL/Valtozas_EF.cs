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

        public void ValtozasRogzitese(Action sikerkor, Action kivetelkor)
        {
            try
            {
                context.SaveChanges();
                sikerkor?.Invoke();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                if (kivetelkor != null)
                {
                    kivetelkor();
                }
                else throw;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion

    }
}
