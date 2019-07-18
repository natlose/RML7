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
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void ErtekadasErtesites<T>(ref T mezo, T ertek, [CallerMemberName] string tulajdonsagNeve = null)
        {
            mezo = ertek;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNeve));
        }

        protected void Ertesites([CallerMemberName] string tulajdonsagNeve = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNeve));
        }
    }
}
