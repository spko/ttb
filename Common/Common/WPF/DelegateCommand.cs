using System;
using System.Windows.Input;

namespace Spo.ToolsTestsBenchmarks.Common.Common.WPF
{
    public class DelegateCommand<T> : ICommand where T : class
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
            T concreteParam = parameter as T;

            return this.canExecuteDelegate(concreteParam);
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter">Command input parameter</param>
        public void Execute(object parameter)
        {
            T concreteParam = parameter as T;

            this.executeDelegate(concreteParam);
        }

        #endregion
    }
}
