using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Partner : Megfigyelheto
    {
        private Partner(){}

        public Partner(int id)
        {

        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                MegfigyelokErtesitese();
            }
        }

        private string mj;
        public string MJ // M-magánszemély, J-jogi személy
        {
            get { return mj; }
            set
            {
                mj = value;
                MegfigyelokErtesitese();
            }
        }

        private Maganszemely maganszemely;
        /// <summary>
        /// Ha az MJ értéke M, akkor ez az identitása
        /// </summary>
        public Maganszemely Maganszemely
        {
            get { return maganszemely; }
            set
            {
                maganszemely = value;
                MegfigyelokErtesitese();
            }
        }

        private Jogiszemely jogiszemely;
        /// <summary>
        /// Ha az MJ értéke J, akkor ez az identitása
        /// </summary>
        public Jogiszemely Jogiszemely
        {
            get { return jogiszemely; }
            set
            {
                jogiszemely = value;
                MegfigyelokErtesitese();
            }
        }

        private Elerhetoseg elerhetoseg;

        public Elerhetoseg Elerhetoseg
        {
            get { return elerhetoseg; }
            set
            {
                elerhetoseg = value;
                MegfigyelokErtesitese();
            }
        }

        private ICollection<PostaCim> postaCimek;

        public ICollection<PostaCim> PostaCimek
        {
            get { return postaCimek; }
            set
            {
                postaCimek = value;
                MegfigyelokErtesitese();
            }
        }

    }
}
