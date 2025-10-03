using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF30SEP.Infrastructure.Commands
{
    public class CloseStudentEditorWindow : Infrastructure.Commands.Base.Command
    {
        protected override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (System.Windows.Window)parameter;
            window.Close();
        }

        protected override bool CanExecute(object? parameter) => parameter is System.Windows.Window;
    }

    public class CloseStudentEditorDialog : Infrastructure.Commands.Base.Command
    {
        public bool? DialogResult { get; set; } 
        protected override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (System.Windows.Window)parameter;
            window.DialogResult = DialogResult;
            window.Close();
        }

        protected override bool CanExecute(object? parameter) => parameter is System.Windows.Window;
    }
}
