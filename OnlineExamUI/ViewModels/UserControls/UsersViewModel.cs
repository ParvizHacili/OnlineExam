using OnlineExamUI.Commands.Users;
using System;
using System.Collections.Generic;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.UserControls
{
    public class UsersViewModel : BaseControlViewModel
    {
        public UsersViewModel()
        {

        }
        public override string Header =>"İstifadəçilər";

        public SaveUserCommand Save => new SaveUserCommand(this);
    }
}
