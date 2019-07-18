using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sajat.WPF
{
    public class Parancs : ICommand
    {
        private Action<object> vegrehajto;
        private Func<object, bool> szabadVegrehajtani;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Parancs(Action<object> vegrehajto, Func<object, bool> szabadVegrehajtani = null)
        {
            this.vegrehajto = vegrehajto;
            this.szabadVegrehajtani = szabadVegrehajtani;
        }

        public bool CanExecute(object parameter)
        {
            return this.szabadVegrehajtani == null || this.szabadVegrehajtani(parameter);
        }

        public void Execute(object parameter)
        {
            this.vegrehajto(parameter);
        }
    }
}
