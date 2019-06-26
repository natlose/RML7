using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public class Ellenorizheto : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private Dictionary<string, List<string>> hibauzenetek = new Dictionary<string, List<string>>();

        protected void ErtekadasErtesitesEllenorzes<T>(ref T mezo, T ertek, [CallerMemberName] string tulajdonsagNeve = null)
        {
            // Értékadás
            mezo = ertek;
            // Értesítés
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNeve));
            // Ellenőrzés
            // Alkalmazható attribútumok: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.8
            List<ValidationResult> validatorEredmeny = new List<ValidationResult>();
            int korabbiLetszam = 0;
            int frissLetszam = 0;
            if (hibauzenetek.ContainsKey(tulajdonsagNeve))
            {
                korabbiLetszam = hibauzenetek[tulajdonsagNeve].Count;
                hibauzenetek.Remove(tulajdonsagNeve);
            }
            if (!Validator.TryValidateProperty(ertek, new ValidationContext(this, null, null) { MemberName = tulajdonsagNeve}, validatorEredmeny))
            {
                List<string> frissUzenetek = validatorEredmeny.Select(h => h.ErrorMessage).ToList();
                hibauzenetek.Add(tulajdonsagNeve, frissUzenetek);
                frissLetszam = frissUzenetek.Count;
            }
            if (frissLetszam != korabbiLetszam) ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(tulajdonsagNeve));
        }

        protected void ErtekadasErtesites<T>(ref T mezo, T ertek, [CallerMemberName] string propertyName = null)
        {
            mezo = ertek;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
