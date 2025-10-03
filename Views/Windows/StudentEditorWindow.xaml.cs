using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPF30SEP.Views.Windows
{
    /// <summary>
    /// Interaction logic for StudentEditorWindow.xaml
    /// </summary>
    public partial class StudentEditorWindow : Window
    {
        #region FirstNameProperty
        // Регистрация свойства
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register(
                "FirstName",
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        [Description("FirstName")]
        public string FirstName
        {
            get => (string)GetValue(FirstNameProperty);
            set => SetValue(FirstNameProperty, value);
        }

        #endregion

        #region LastNameProperty
        // Регистрация свойства
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                "LastName",
                typeof(string),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(string)));

        // Обёртка для доступа к свойству
        [Description("LastName")]
        public string LastName
        {
            get => (string)GetValue(LastNameProperty);
            set => SetValue(LastNameProperty, value);
        }

        #endregion

        public StudentEditorWindow()
        {
            InitializeComponent();
        }
    }
}
