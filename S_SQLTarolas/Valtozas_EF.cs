﻿using Sajat.ObjektumModel;
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

        private bool vanUtkozes = false;
        public bool VanUtkozes
        {
            get => vanUtkozes;
        }

        public bool ValtozasRogzitese()
        {
            try
            {
                vanUtkozes = false;
                context.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                vanUtkozes = true;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion
    }
}
