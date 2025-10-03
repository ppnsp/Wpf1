using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using WPF30SEP.Views.Windows;

namespace WPF30SEP.Infrastructure.Commands
{
    public class ManageStudentCommand : Base.Command
    {
        private ModalWindow _modalWindow;        
        protected override void Execute(object? parameter)
        {
            var window = new ModalWindow
            {
                Owner = Application.Current.MainWindow
            };

            _modalWindow = window;
            window.Closed += CloseWin;
            _modalWindow.ShowDialog();

        }

        private void CloseWin(object? sender, EventArgs e)
        {
            ((Window) sender).Closed -= CloseWin;
            _modalWindow = null;
        }

        protected override bool CanExecute(object? parameter) => _modalWindow == null;
    }
}
