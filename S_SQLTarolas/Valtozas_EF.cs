using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.SQLTarolas
{
    public class Valtozas_EF<TContext> : IEgysegnyiValtozas where TContext : DbContext
    {
        protected TContext context;

        #region IEgysegnyiValtozas
        public bool VanValtozas
        {
            get => context.ChangeTracker.HasChanges();
        }

        public RogzitesEredmeny ValtozasRogzitese()
        {
            try
            {
                context.SaveChanges();
                return RogzitesEredmeny.Siker;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                return RogzitesEredmeny.Versenyhelyzet;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return RogzitesEredmeny.ErvenytelenAdat;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return RogzitesEredmeny.NemTarolhato;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion
    }
}
