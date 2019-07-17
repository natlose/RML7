using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class Valtozas_EF : IValtozas
    {
        private readonly SajatContext context;

        public Valtozas_EF(SajatContext context)
        {
            this.context = context;
            tarolok = new Tarolok_EF(context);
        }

        #region IValtozas
        private ITarolok tarolok;
        public ITarolok Tarolok => tarolok;
        #endregion

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
