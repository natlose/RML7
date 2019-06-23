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
    public class Ellenorizheto : Megfigyelheto, INotifyDataErrorInfo
    {

        #region Hibaüzenetek nyilvántartása
        private Dictionary<string, List<string>> hibauzenetek = new Dictionary<string, List<string>>();

        protected void TulajdonsagEllenorzesKezdete([CallerMemberName] string tulajdonsagNeve = null)
        {
            hibauzenetek.Remove(tulajdonsagNeve);
            hibauzenetek.Add(tulajdonsagNeve, new List<string>());
        }

        protected void TulajdonsagHibauzenet(string hibauzenet, [CallerMemberName] string tulajdonsagNeve = null)
        {
            hibauzenetek[tulajdonsagNeve]?.Add(hibauzenet);
        }

        protected void TulajdonsagEllenorzesVege([CallerMemberName] string tulajdonsagNeve = null)
        {
            if (hibauzenetek[tulajdonsagNeve].Count == 0) hibauzenetek.Remove(tulajdonsagNeve);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(tulajdonsagNeve));
            MegfigyelokErtesitese(nameof(HasErrors));
        }
        #endregion

        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => (hibauzenetek.Count > 0);

        public IEnumerable GetErrors(string tulajdonsagNeve)
        {
            if (String.IsNullOrEmpty(tulajdonsagNeve))
            {
                return hibauzenetek.Values;
            }
            else
            {
                if (hibauzenetek.ContainsKey(tulajdonsagNeve)) return hibauzenetek[tulajdonsagNeve];
                else return null;
            }
        }
        #endregion
    }
}
