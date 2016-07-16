using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DieHardWpf.Commands
{
    public class TickCommand : ICommand
    {
        public DieHardViewModel DieHardViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public TickCommand(DieHardViewModel dieHardViewModel)

        {
            DieHardViewModel = dieHardViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DieHardViewModel.Tick();
        }
    }
}
