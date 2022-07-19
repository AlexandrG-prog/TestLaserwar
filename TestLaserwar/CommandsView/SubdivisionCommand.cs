﻿using System;
using System.Windows.Input;

namespace TestLaserwar.CommandsView
{
    /// <summary>
    /// Команда для работы с подразделениями
    /// </summary>
    public class SubdivisionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _func(parameter);
        }

        private Action<object> _func;

        public SubdivisionCommand(Action<object> func)
        {
            _func = func;
        }
    }
}
