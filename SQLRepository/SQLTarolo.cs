using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Partner;

namespace SQLTarolo
{
    public class SQLTarolo : DbContext, Partner.IPartnerTarolo
    {
        public SQLTarolo() : base("DEV") { }

        public void ValtozasokTarolasa()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        #region Partner.IPartnerTarolo
        private DbSet<Partner.Partner> partnerek { get; set; }
        public IEnumerable<Partner.Partner> Partnerek { get => partnerek;  }
        #endregion
    }
}
