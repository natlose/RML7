using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class CikkContext : DbContext
    {
        public CikkContext() : base("DEV")
        {
#if DEBUG
            Database.Log = Console.Write;
#endif
            Database.SetInitializer<CikkContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region FoCsoport
            modelBuilder.Entity<FoCsoport>().ToTable("FoCsoport", "Cikk");
            modelBuilder.Entity<FoCsoport>().Property(p => p.Nev)
                .HasColumnName("Nev")
                .IsUnicode();
            #endregion
        }

        public DbSet<FoCsoport> FoCsoportok { get; set; }
    }
}
