using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Users
{
   public abstract class BaseUserCommand :BaseCommand
    {
        protected readonly UsersViewModel viewModel;
        public BaseUserCommand(UsersViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
