using System;
using System.Windows.Input;

namespace Kursach.Infrastructure.Commands
{
    public class CompleteOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> executer;

        public CompleteOrderCommand(Action<object> executer)
        {
            this.executer = executer;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(executer != null)
            {
                executer.Invoke(parameter);
            }
        }
    }
}
