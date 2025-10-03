using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF30SEP.ViewModels.Base;

namespace WPF30SEP.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title: string
        private string _title = "Texs";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
    }
}
