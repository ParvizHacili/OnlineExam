using OnlineExamUI.ViewModels.UserControls;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.MainPage
{
    public class OpenUsersCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenUsersCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            UsersViewModel usersViewModel = new UsersViewModel();

            UsersControl usersControl = new UsersControl();

            usersControl.DataContext = usersViewModel;
            MainWindow mainWindow = (MainWindow)mainViewModel.Window;

            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(usersControl);
        }
    }
}
