using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF30SEP.Infrastructure.Commands.Base;

namespace WPF30SEP.Infrastructure.Commands
{
    public class CloseWindow : Command
    {
        protected override bool CanExecute(object? parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ISAciveWindow) != null;
        protected override void Execute(object? parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ISAciveWindow).Close();
    }
}
