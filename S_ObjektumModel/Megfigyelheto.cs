using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public class Megfigyelheto : INotifyPropertyChanged
    {
        #region INotifyPropertChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void MegfigyelokErtesitese([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
