using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DEV") {  }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Partner
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<Partner>().Property(p => p.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<Partner>().Property(p => p.MJ)
                .HasColumnName("MJ")
                .IsRequired()
                .HasMaxLength(1);
            modelBuilder.Entity<Partner>().Property(p => p.Maganszemely.Vezeteknev)
                .HasColumnName("MVezeteknev")
                .HasMaxLength(30)
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Maganszemely.Keresztnev)
                .HasColumnName("MKeresztnev")
                .HasMaxLength(30)
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Rovidnev)
                .HasColumnName("JRovidnev")
                .HasMaxLength(30)
                .IsUnicode();
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Cegjegyzekszam)
                .HasColumnName("JCegjegyzekszam")
                .HasMaxLength(30);
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Adoszam)
                .HasColumnName("JAdoszam")
                .HasMaxLength(30);
            modelBuilder.Entity<Partner>().Property(p => p.Jogiszemely.Orszag)
                .HasColumnName("JOrszag")
                .HasMaxLength(2);
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Telefon)
                .HasColumnName("Telefon")
                .HasMaxLength(20);
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Mobil)
                .HasColumnName("Mobil")
                .HasMaxLength(20);
            modelBuilder.Entity<Partner>().Property(p => p.Elerhetoseg.Email)
                .HasColumnName("Email")
                .HasMaxLength(50);
            modelBuilder.Entity<Partner>()
                .HasMany<PostaCim>(p => p.PostaCimek)
                .WithRequired(c => c.Partner)
                .Map(f => f.MapKey("fiPartner"));

            #endregion

            #region PostaCim
            modelBuilder.Entity<PostaCim>().ToTable("PostaCim");
            modelBuilder.Entity<PostaCim>().Property(p => p.Tipus)
                .HasColumnName("Tipus")
                .IsRequired()
                .HasMaxLength(1);
            modelBuilder.Entity<PostaCim>().Property(p => p.Orszag)
                .HasColumnName("Orszag")
                .HasMaxLength(2);
            modelBuilder.Entity<PostaCim>().Property(p => p.Iranyitoszam)
                .HasColumnName("Irsz")
                .HasMaxLength(15);
            modelBuilder.Entity<PostaCim>().Property(p => p.Helyseg)
                .HasColumnName("Helyseg")
                .HasMaxLength(30)
                .IsUnicode();
            modelBuilder.Entity<PostaCim>().Property(p => p.Sor1)
                .HasColumnName("Sor1")
                .HasMaxLength(30)
                .IsUnicode();
            modelBuilder.Entity<PostaCim>().Property(p => p.Sor2)
                .HasColumnName("Sor2")
                .HasMaxLength(30)
                .IsUnicode();
            #endregion
        }

        public DbSet<Partner> Partnerek { get; set; }

        public DbSet<PostaCim> PostaCimek { get; set; }

    }
}
