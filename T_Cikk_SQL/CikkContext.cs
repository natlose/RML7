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
                .HasColumnName("nev")
                .IsUnicode();
            modelBuilder.Entity<FoCsoport>()
                .HasMany<AlCsoport>(p => p.AlCsoportok)
                .WithRequired(c => c.FoCsoport)
                .Map(f => f.MapKey("fi_FoCsoport"));
            #endregion

            #region AlCsoport
            modelBuilder.Entity<AlCsoport>().ToTable("AlCsoport", "Cikk");
            modelBuilder.Entity<AlCsoport>().Property(p => p.Nev)
                .HasColumnName("nev")
                .IsUnicode();
            modelBuilder.Entity<AlCsoport>()
                .HasMany<Cikk>(p => p.Cikkek)
                .WithOptional(e => e.AlCsoport)
                .Map(f => f.MapKey("fi_AlCsoport"));
            #endregion

            #region Cikk
            modelBuilder.Entity<Cikk>().ToTable("Cikk", "Cikk");
            modelBuilder.Entity<Cikk>().Property(p => p.Cikkszam)
                .HasColumnName("cikkszam");
            modelBuilder.Entity<Cikk>().Property(p => p.Nev)
                .HasColumnName("nev")
                .IsUnicode();
            modelBuilder.Entity<Cikk>().Property(p => p.MEgys)
                .HasColumnName("megys")
                .IsUnicode();
            modelBuilder.Entity<Cikk>().Property(p => p.GyartoiCikkszam)
                .HasColumnName("gyartoi_cikkszam");
            modelBuilder.Entity<Cikk>().Property(p => p.AngolNev)
                .HasColumnName("angol_nev")
                .IsUnicode();
            #endregion

        }

        public DbSet<FoCsoport> FoCsoportok { get; set; }

        public DbSet<AlCsoport> AlCsoportok { get; set; }

        public DbSet<Cikk> Cikkek { get; set; }
    }
}
