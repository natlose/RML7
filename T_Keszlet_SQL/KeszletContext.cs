using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class KeszletContext : DbContext
    {
        public KeszletContext() : base("DEV")
        {
#if DEBUG
            Database.Log = Console.Write;
#endif
            Database.SetInitializer<KeszletContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Raktar
            modelBuilder.Entity<Raktar>().ToTable("Raktar", "Keszlet");
            modelBuilder.Entity<Raktar>().Property(p => p.Nev)
                .HasColumnName("nev")
                .IsUnicode();
            modelBuilder.Entity<Raktar>()
                .HasMany<Polc>(p => p.Polcok)
                .WithRequired(c => c.Raktar)
                .Map(f => f.MapKey("fi_Raktar"));
            #endregion

            #region Polc
            modelBuilder.Entity<Polc>().ToTable("Polc", "Keszlet");
            modelBuilder.Entity<Polc>().Property(p => p.Kod)
                .HasColumnName("kod");
            modelBuilder.Entity<Polc>().Property(p => p.Megjegyzes)
                .HasColumnName("megjegyzes")
                .IsUnicode();
            modelBuilder.Entity<Polc>()
                .HasMany<Keszlet>(p => p.Keszletek)
                .WithRequired(e => e.Polc)
                .Map(f => f.MapKey("fi_Polc"));
            #endregion

            #region Keszlet
            modelBuilder.Entity<Keszlet>().ToTable("Keszlet", "Keszlet");
            modelBuilder.Entity<Keszlet>().Property(p => p.CikkID)
                .HasColumnName("fi_Cikk");
            modelBuilder.Entity<Keszlet>().Property(p => p.Meny)
                .HasColumnName("meny");
            #endregion
        }

    }
}
