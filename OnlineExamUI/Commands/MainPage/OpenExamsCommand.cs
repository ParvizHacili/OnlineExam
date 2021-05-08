using Exam.Core.Domain.Entities;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
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
    public class OpenExamsCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenExamsCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel; 
        }

        public override void Execute(object parameter)
        {
            ExamsViewModel examsViewModel = new ExamsViewModel();

            List<ExamModel> examModels = DataProvider.GetExams();
            EnumerationUtil.Enumerate(examModels);

            examsViewModel.AllExams = examModels;
            examsViewModel.Exams = new ObservableCollection<ExamModel>(examModels);
            examsViewModel.CurrentExam = new ExamModel();

            ExamsControl examsControl = new ExamsControl();

            examsControl.DataContext = examsViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(examsControl);
        }
    }
}
