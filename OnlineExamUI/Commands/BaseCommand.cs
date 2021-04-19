using Exam.Core;
using Exam.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OnlineExamUI.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected IUnitOfWork DB => Kernel.DB;

        public event EventHandler CanExecuteChanged;


        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
