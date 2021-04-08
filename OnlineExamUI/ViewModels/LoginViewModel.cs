using OnlineExamUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OnlineExamUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
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

        public Window Window;
    }
}
