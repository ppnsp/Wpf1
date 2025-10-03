using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WPF30SEP.Services.Interface
{
    public interface IUserDialogService
    {
        bool Edit(object item);

        void ShowInfomation(string information, string capture);

        void ShowWarning(string meassage, string capture);

        void ShowError(string meassage, string capture);

        bool Confirm(string meassage, string capture, bool Exclamation = true);
    }
}
