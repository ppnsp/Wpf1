using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF30SEP.Infrastructure.Commands.Base;

namespace WPF30SEP.Infrastructure
{
    public class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // Первый конструктор с Action<object>


        // Второй конструктор с Action (без параметра)        
        public LambdaCommand(Action execute, Func<object, bool> canExecute = null)
            : this(
                parameter => execute(),
                canExecute ?? (parameter => true))
        {
        }

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            
            MethodWithTwoParamsDelegate((p, k) => MyFunctionWithoutParams());
        }

        public void MethodWithTwoParamsDelegate(Func<int, string, string> func)
        {
            // Вызываем переданный делегат
            string result = func(10, "test");
            Console.WriteLine(result);
        }

        // Наша функция без параметров
        public string MyFunctionWithoutParams()
        {
            return "Результат без параметров";
        }


        protected override bool CanExecute(object parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        protected override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            _execute(parameter);
        }
    }
}
