using OnlineExamUI.Helpers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OnlineExamUI.Commands.MainPage
{
   public class OpenOnlineExamCommand :BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenOnlineExamCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {

            OnlineExamsViewModel onlineExamsViewModel = new OnlineExamsViewModel();
            OnlineExamControl onlineExamControl = new OnlineExamControl();

            onlineExamControl.DataContext = onlineExamsViewModel;


            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(onlineExamControl);
        }
    }
}
