using Exam.Core.Domain.Entities;
using Exam.ViewModels.UserControls;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<SubjectModel> subjectModels = DataProvider.GetSubjects();

            EnumerationUtil.Enumerate(subjectModels);

            SubjectsViewModel subjectsViewModel = new SubjectsViewModel();
            subjectsViewModel.AllSubjects = subjectModels;

            SubjectsControl subjectsControl = new SubjectsControl();

            subjectsControl.DataContext = subjectsViewModel;
            subjectsViewModel.Subjects = new ObservableCollection<SubjectModel>(subjectModels);

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(subjectsControl);
        }
    }
}
