﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdvanceNavigation.Commands
{
    public abstract class CommandBase : ICommand
    {
            public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        protected void OnCahExecuteChange() { 
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
