using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PartnerTarolo_EF : Tarolo_EF<Partner>, IPartnerTarolo
    {
        public PartnerTarolo_EF(PartnerContext context) : base(context) { }

        public Partner EgyetlenEsPostaCimek(int id)
        {
            return (context as PartnerContext).Partnerek.Include(p => p.PostaCimek).Single(p => p.Id == id);
        }

        public IEnumerable<Partner> MindAholReszletek(string nev, string mobil, string telefon, string email, string cegjegyzekszam, string adoszam, string orszag)
        {
            StringMuveletek.UresbolLegyenNull(ref nev);
            StringMuveletek.UresbolLegyenNull(ref mobil);
            StringMuveletek.UresbolLegyenNull(ref telefon);
            StringMuveletek.UresbolLegyenNull(ref email);
            StringMuveletek.UresbolLegyenNull(ref cegjegyzekszam);
            StringMuveletek.UresbolLegyenNull(ref adoszam);
            StringMuveletek.UresbolLegyenNull(ref orszag);
            return (context as PartnerContext).Partnerek.Where(
                p => 
                (nev == null || p.Nev.Contains(nev))
                && (mobil == null || p.Elerhetoseg.Mobil.Contains(mobil))
                && (telefon == null || p.Elerhetoseg.Telefon.Contains(telefon))
                && (email == null || p.Elerhetoseg.Email.Contains(email))
                && (cegjegyzekszam == null || p.MJ == "J" && p.Jogiszemely.Cegjegyzekszam.Contains(cegjegyzekszam))
                && (adoszam == null || p.MJ == "J" && p.Jogiszemely.Adoszam.Contains(adoszam))
                && (orszag == null || p.MJ == "J" && p.Jogiszemely.Orszag == orszag)
                ).ToList();
        }
    }
}
