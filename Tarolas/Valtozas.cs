using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class Valtozas : IDisposable
    {
        private readonly SajatContext context;

        public Valtozas(SajatContext context)
        {
            this.context = context;
        }

        public SajatContext Context => context;

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
    }
}
