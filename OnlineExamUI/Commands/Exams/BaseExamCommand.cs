using OnlineExamUI.ViewModels.UserControls;
using OnlineExamUI.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Exams
{
    public abstract class BaseExamCommand :BaseCommand
    {
        protected readonly ExamsViewModel viewModel;
        public BaseExamCommand (ExamsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
