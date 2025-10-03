using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WPF30SEP.Infrastructure;
using WPF30SEP.Models;
using WPF30SEP.Services;
using WPF30SEP.Views.Windows;

namespace WPF30SEP.ViewModels
{
    public class DecanatViewModel : INotifyPropertyChanged
    {
        private WindowUserDialogService windowUserDialogService;
        public DecanatViewModel() 
        { 
            windowUserDialogService = new();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _name = "Texs";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private IEnumerable<Models.Group> _groups = TestData.Groups;

        public IEnumerable<Models.Group> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged();
                }
            }
        }
        #region _selectedGroup

        private Models.Group _selectedGroup;

        public Models.Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SelectedStudent

        private Student _selectedStudent;

        public Student SelectedStudent 
        { 
            get => _selectedStudent; 
            set
            {
                _selectedStudent = value;   
                OnPropertyChanged();
            }
        }
        #endregion

        #region EditCommond

        ICommand _editStudentCommand;

        public ICommand EditStudentCommand => _editStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecute, CanEditStudentCommandExecute);

        private bool CanEditStudentCommandExecute(object p) => p is Student;

        private void OnEditStudentCommandExecute(object p)
        {
            windowUserDialogService.Edit(p);

            Console.WriteLine(" " + (Student)p);
            EditSelectedUser((Student)p);
            /*

                        var student = (Student)p;
                        var dlg = new StudentEditorWindow
                        {
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                        };

                        if (dlg.ShowDialog() == true)
                        {
                            MessageBox.Show("Data was Edited");
                        }
                        else
                        {
                            MessageBox.Show("Operation was Changed");
                        }
            */
        }

        #endregion

        #region CreateCommond

        ICommand _createStudentCommand;

        ICommand CreateStudentCommand => _createStudentCommand ??= new LambdaCommand(OnCreateStudentCommandExecute, CanCreateStudentCommandExecute);

        private bool CanCreateStudentCommandExecute(object p) => p is Models.Group;

        private void OnCreateStudentCommandExecute(object p)
        {
            var group = (Models.Group)p;
        }

        #endregion


        private void EditSelectedUser(Student s)
        {
            SelectedStudent.FirstName = s.FirstName;
            SelectedStudent.LastName = s.LastName;
            OnPropertyChanged(nameof(SelectedStudent));
            OnPropertyChanged(nameof(SelectedGroup));
        }
    }
}
