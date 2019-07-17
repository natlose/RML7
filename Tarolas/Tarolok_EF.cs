using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class Tarolok_EF : ITarolok
    {
        private readonly SajatContext context;

        public Tarolok_EF(SajatContext context)
        {
            orszagok = new Tarolo_EF<Orszag>(context);
            irszamok = new Tarolo_EF<Irszam>(context);
            partnerek = new Tarolo_EF<Partner>(context);
            raktarak = new Tarolo_EF<Raktar>(context);
            polcok = new Tarolo_EF<Polc>(context);
            keszletek = new Tarolo_EF<Keszlet>(context);
            foCsoportok = new Tarolo_EF<FoCsoport>(context);
            alCsoportok = new Tarolo_EF<AlCsoport>(context);
            cikkek = new Tarolo_EF<Cikk>(context);
            this.context = context;
        }

        private ITarolo<Orszag> orszagok;
        public ITarolo<Orszag> Orszagok => orszagok;

        private ITarolo<Irszam> irszamok;
        public ITarolo<Irszam> Irszamok => irszamok;

        private ILapozhatoTarolo<Partner> partnerek;
        public ILapozhatoTarolo<Partner> Partnerek => partnerek;

        private ITarolo<Raktar> raktarak;
        public ITarolo<Raktar> Raktarak => raktarak;

        private ITarolo<Polc> polcok;
        public ITarolo<Polc> Polcok => polcok;

        private ITarolo<Keszlet> keszletek;
        public ITarolo<Keszlet> Keszletek => keszletek;

        private ITarolo<FoCsoport> foCsoportok;
        public ITarolo<FoCsoport> FoCsoportok => foCsoportok;

        private ITarolo<AlCsoport> alCsoportok;
        public ITarolo<AlCsoport> AlCsoportok => alCsoportok;

        private ITarolo<Cikk> cikkek;
        public ITarolo<Cikk> Cikkek => cikkek;

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
