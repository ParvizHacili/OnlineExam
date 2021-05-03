using OnlineExamUI.Enums;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Users
{
   public  class SaveUserCommand : BaseUserCommand
    {
        public SaveUserCommand(UsersViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if (viewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
            }
            else
            {
                if (viewModel.CurrentSituation == (int)Situation.ADD || viewModel.CurrentSituation == (int)Situation.EDIT)
                {

                }
            }
        }
    }
}
