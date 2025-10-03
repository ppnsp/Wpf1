using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF30SEP.Models;
using WPF30SEP.Services.Interface;
using WPF30SEP.Views;
using WPF30SEP.Views.Windows;

namespace WPF30SEP.Services
{
    public class WindowUserDialogService : IUserDialogService
    {
        public bool Confirm(string meassage, string capture, bool Exclamation = true)
        {
            return MessageBox.Show(
                meassage,
                capture, 
                MessageBoxButton.YesNo, 
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;
        }

        public bool Edit(object item)
        {
            if (item is null) return false;

            switch (item)
            {
                default: throw new NotSupportedException($"The object {item.GetType().Name} is not supported.");
                case Student student: return EditStudent(student);
            }
        }

        public void ShowError(string meassage, string capture)
        {
            throw new NotImplementedException();
        }

        public void ShowInfomation(string information, string capture)
        {
            throw new NotImplementedException();
        }

        public void ShowWarning(string meassage, string capture)
        {
            MessageBox.Show(null);
        }

        private static bool EditStudent(Student student)
        {
            var dlg = new StudentEditorWindow
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Owner = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(),
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            if (dlg.ShowDialog() != true) return false;

            student.FirstName = dlg.FirstName;
            student.LastName = dlg.LastName;


            return true;
        }
    }
}
