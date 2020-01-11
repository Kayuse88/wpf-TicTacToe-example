using System;
using System.Windows.Input;

namespace TicTacToeExample.Command
{
    // Refer to Prism Library.
    // https://github.com/PrismLibrary/Prism/blob/master/Source/Prism/Commands/DelegateCommand%7BT%7D.cs
    public class SimpleCommand<T> : ICommand
    {
        #region Fields
        private Func<T, bool> canMethod;
        private Action<T> method;
        #endregion

        #region Constructors
        public SimpleCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod = null)
        {
            if (executeMethod == null)
                throw new ArgumentNullException(nameof(executeMethod));

            method = executeMethod;
            canMethod = canExecuteMethod ?? ((o) => true);
        }
        #endregion

        #region ICommand Implementation
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(T parameter)
        {
            return canMethod(parameter);
        }

        public void Execute(T parameter)
        {
            method(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }
        #endregion
    }
}
