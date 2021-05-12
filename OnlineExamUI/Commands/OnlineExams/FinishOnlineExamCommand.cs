using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.OnlineExams
{
    public class FinishOnlineExamCommand : BaseOnlineExamCommand
    {
        public FinishOnlineExamCommand(OnlineExamsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
