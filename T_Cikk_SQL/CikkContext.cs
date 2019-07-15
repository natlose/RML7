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
            modelBuilder.Entity<FoCsoport>()
                .HasMany<AlCsoport>(p => p.AlCsoportok)
                .WithRequired(c => c.FoCsoport)
                .Map(f => f.MapKey("fi_FoCsoport"));
            #endregion

            #region AlCsoport
            modelBuilder.Entity<AlCsoport>().ToTable("AlCsoport", "Cikk");
            modelBuilder.Entity<AlCsoport>().Property(p => p.Nev)
                .HasColumnName("Nev")
                .IsUnicode();
            #endregion
        }

        public DbSet<FoCsoport> FoCsoportok { get; set; }

        public DbSet<AlCsoport> AlCsoportok { get; set; }
    }
}
