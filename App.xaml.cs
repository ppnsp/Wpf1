using System.Configuration;
using System.Data;
using System.Windows;

namespace WPF30SEP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window ISAciveWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);
    }

}
