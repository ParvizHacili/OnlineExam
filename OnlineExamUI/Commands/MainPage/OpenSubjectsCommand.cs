using Exam.ViewModels.UserControls;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.MainPage
{
    public class OpenSubjectsCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenSubjectsCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            SubjectsViewModel subjectsViewModel = new SubjectsViewModel();

            SubjectsControl subjectsControl = new SubjectsControl();

            subjectsControl.DataContext = subjectsViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(subjectsControl);

        }
    }
}
