using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Exams
{
   public  class DeleteExamCommand :BaseExamCommand
    {
        public DeleteExamCommand(ExamsViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
