using System;
using System.Windows.Input;

namespace Spo.ToolsTestsBenchmarks.Common.Common.WPF
{
    public class DelegateCommand<T> : ICommand
    {
        #region Private Fields

        private readonly Predicate<T> canExecuteDelegate;
        private readonly Action<T> executeDelegate;

        #endregion

        #region Constructor

        public DelegateCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.canExecuteDelegate = canExecute;
            this.executeDelegate = execute;
        }

        public DelegateCommand(Func<bool> canExecute, Action execute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            this.canExecuteDelegate = s => canExecute();
            this.executeDelegate = s => execute();
        }

        #endregion

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region Public Methods

        /// <summary>
        /// Evaluates the can execute status of the command
        /// </summary>
        /// <param name="parameter">Input command parameter</param>
        /// <returns><c>True</c> of <c>False</c> indicating if the command can be executed or not</returns>
        public bool CanExecute(object parameter)
        {
            if (parameter is T)
            {
                T concreteParam = (T)parameter;

                return this.canExecuteDelegate(concreteParam);
            }
            else if (parameter == null)
            {
                return this.canExecuteDelegate(default(T));
            }

            return false;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter">Command input parameter</param>
        public void Execute(object parameter)
        {
            if (parameter is T)
            {
                T concreteParam = (T)parameter;

                this.executeDelegate(concreteParam);
            }
            else if (parameter == null)
            {
                this.executeDelegate(default(T));
            }
        }

        #endregion
    }
}
