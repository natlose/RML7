using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class SajatContext : DbContext
    {
        public SajatContext() : base("DEV")
        {
            #if DEBUG
            Database.Log = Console.Write;
            #endif
            Database.SetInitializer<SajatContext>(null);
        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Partner
            modelBuilder.Entity<Partner>().ToTable("Partner", "Partner");

            modelBuilder.Entity<Partner>().Property(p => p.MJ)
                .HasColumnName("MJ");
            modelBuilder.Entity<Partner>().Property(p => p.Nev)
                .HasColumnName("Nev")
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Maganszemely.Vezeteknev)
                .HasColumnName("MVezeteknev")
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Maganszemely.Keresztnev)
                .HasColumnName("MKeresztnev")
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Rovidnev)
                .HasColumnName("JRovidnev")
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Cegjegyzekszam)
                .HasColumnName("JCegjegyzekszam");
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Adoszam)
                .HasColumnName("JAdoszam");
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Orszag)
                .HasColumnName("JOrszag");
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Telefon)
                .HasColumnName("Telefon");
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Mobil)
                .HasColumnName("Mobil");
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Email)
                .HasColumnName("Email");
            modelBuilder.Entity<Partner>()
                .HasMany<PostaCim>(p => p.PostaCimek)
                .WithRequired(c => c.Partner)
                .Map(f => f.MapKey("fiPartner"));

            #endregion

            #region PostaCim
            modelBuilder.Entity<PostaCim>().ToTable("PostaCim", "Partner");
            modelBuilder.Entity<PostaCim>().Property(p => p.Tipus)
                .HasColumnName("Tipus");
            modelBuilder.Entity<PostaCim>().Property(p => p.Orszag)
                .HasColumnName("Orszag");
            modelBuilder.Entity<PostaCim>().Property(p => p.Iranyitoszam)
                .HasColumnName("Irsz");
            modelBuilder.Entity<PostaCim>().Property(p => p.Helyseg)
                .HasColumnName("Helyseg")
                .IsUnicode();
            modelBuilder.Entity<PostaCim>().Property(p => p.Sor1)
                .HasColumnName("Sor1")
                .IsUnicode();
            modelBuilder.Entity<PostaCim>().Property(p => p.Sor2)
                .HasColumnName("Sor2")
                .IsUnicode();
            #endregion

            #region Orszag
            modelBuilder.Entity<Orszag>().ToTable("Orszag", "Partner");
            modelBuilder.Entity<Orszag>().Property(p => p.Iso)
                .HasColumnName("Iso");
            modelBuilder.Entity<Orszag>().Property(p => p.Nev)
                .HasColumnName("Nev")
                .IsUnicode();
            #endregion

            #region Irszam
            modelBuilder.Entity<Irszam>().ToTable("Irszam", "Partner");
            modelBuilder.Entity<Irszam>().Property(p => p.Orszagkod)
                .HasColumnName("orszagkod");
            modelBuilder.Entity<Irszam>().Property(p => p.Iranyitoszam)
                .HasColumnName("irszam");
            modelBuilder.Entity<Irszam>().Property(p => p.Helyseg)
                .HasColumnName("helyseg");
            #endregion

            #region Koltseghely
            modelBuilder.Entity<Koltseghely>().ToTable("Ktgh", "Partner");
            modelBuilder.Entity<Koltseghely>().Property(p => p.Nev)
                .HasColumnName("nev");
            modelBuilder.Entity<Koltseghely>().Property(p => p.Megjegyzes)
                .HasColumnName("megjegyzes")
                .IsUnicode();
            #endregion

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
            modelBuilder.Entity<Cikk>()
                .HasMany<Keszlet>(p => p.Keszletek)
                .WithRequired(e => e.Cikk)
                .Map(f => f.MapKey("fi_Cikk"));
            #endregion

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
            modelBuilder.Entity<Keszlet>().Property(p => p.Meny)
                .HasColumnName("meny");
            #endregion

            #region MozgasFej
            modelBuilder.Entity<MozgasFej>().ToTable("MozgasFej", "Mozgas");
            modelBuilder.Entity<MozgasFej>().Property(p => p.Piszkozat)
                .HasColumnName("piszkozat");
            modelBuilder.Entity<MozgasFej>().Property(p => p.Mozgasnem)
                .HasColumnName("mozgasnem");
            modelBuilder.Entity<MozgasFej>().Property(p => p.Irany)
                .HasColumnName("irany");
            modelBuilder.Entity<MozgasFej>().Property(p => p.Kelt)
                .HasColumnName("kelt");
            modelBuilder.Entity<MozgasFej>().Property(p => p.Sorszam)
                .HasColumnName("sorszam");
            modelBuilder.Entity<MozgasFej>()
                .HasOptional(p => p.Partner)
                .WithMany()
                .Map(f => f.MapKey("fi_Partner"));
            modelBuilder.Entity<MozgasFej>()
                .HasOptional(p => p.Koltseghely)
                .WithMany()
                .Map(f => f.MapKey("fi_Ktgh"));
            modelBuilder.Entity<MozgasFej>()
                .HasMany(p => p.Tetelek)
                .WithRequired(p => p.MozgasFej)
                .Map(f => f.MapKey("fi_MozgasFej"));
            #endregion

            #region MozgasTetel
            modelBuilder.Entity<MozgasTetel>().ToTable("MozgasTetel", "Mozgas");
            modelBuilder.Entity<MozgasTetel>().Property(p => p.Bsrsz)
                .HasColumnName("bsrsz");
            modelBuilder.Entity<MozgasTetel>()
                .HasRequired(p => p.Cikk)
                .WithMany()
                .Map(f => f.MapKey("fi_Cikk"));
            modelBuilder.Entity<MozgasTetel>().Property(p => p.Meny)
                .HasColumnName("meny");
            modelBuilder.Entity<MozgasTetel>().Property(p => p.EgysAr)
                .HasColumnName("egysar");
            #endregion
        }

        public DbSet<Partner> Partnerek { get; set; }

        public DbSet<PostaCim> PostaCimek { get; set; }

        public DbSet<Orszag> Orszagok { get; set; }

        public DbSet<Irszam> Irszamok { get; set; }

        public DbSet<Koltseghely> Koltseghelyek { get; set; }

        public DbSet<FoCsoport> FoCsoportok { get; set; }

        public DbSet<AlCsoport> AlCsoportok { get; set; }

        public DbSet<Cikk> Cikkek { get; set; }

        public DbSet<Raktar> Raktarak { get; set; }

        public DbSet<Polc> Polcok { get; set; }

        public DbSet<Keszlet> Keszletek { get; set; }

        public DbSet<MozgasFej> MozgasFejek { get; set; }

        public DbSet<MozgasTetel> MozgasTetelek { get; set; }

    }
}
