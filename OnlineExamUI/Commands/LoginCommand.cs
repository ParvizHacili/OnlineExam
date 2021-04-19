using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.ViewModels;
using OnlineExamUI.ViewModels.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OnlineExamUI.Commands
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

            User user = DB.UserRepository.Get(viewModel.Username);

            if (user != null)
            {
                PasswordBox passwordBox = (PasswordBox)parameter;
                string password = passwordBox.Password;
                string passwordHash = SecurityHelper.ComputeSha256Hash(password);

                if (user.Password == passwordHash)
                {
                    Kernel.CurrentUser = user;
                    MainViewModel mainViewModel = new MainViewModel();
                    MainWindow mainWindow = new MainWindow();

                    mainViewModel.Window = mainWindow;

                    mainWindow.DataContext = mainViewModel;
                    mainWindow.Show();
                    viewModel.Window.Close();
                }
                else
                {
                    viewModel.ErrorVisibility = Visibility.Visible;
                }
            }
            else
            {
                viewModel.ErrorVisibility = Visibility.Visible;
            }
        }
    }
}
