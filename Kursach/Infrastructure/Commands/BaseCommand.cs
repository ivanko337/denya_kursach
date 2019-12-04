using System;
using System.Windows.Input;

namespace Kursach.Infrastructure.Commands
{
    public class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Func<object, bool> canExecute;
        private Action<object> execute;

        public BaseCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            if(execute == null)
            {
                return;
            }

            execute.Invoke(parameter);
        }
    }
}
