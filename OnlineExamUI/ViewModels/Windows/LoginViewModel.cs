using OnlineExamUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.Windows
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginCommand SignIn => new LoginCommand(this);

        public string Username { get; set; }

        private Visibility errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => errorVisibility;

            set
            {
                errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

    }
}
