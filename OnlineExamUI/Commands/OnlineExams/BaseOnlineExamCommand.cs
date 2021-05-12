using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.OnlineExams
{
    public abstract class BaseOnlineExamCommand : BaseCommand
    {
        protected readonly OnlineExamsViewModel viewModel;
        public BaseOnlineExamCommand(OnlineExamsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
