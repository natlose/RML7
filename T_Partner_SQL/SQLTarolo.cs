using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class SQLTarolo : DbContext, IPartnerTarolo
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

        #region IPartnerTarolo
        private DbSet<Partner> partnerek { get; set; }
        public IEnumerable<Partner> Partnerek { get => partnerek;  }
        #endregion
    }
}
