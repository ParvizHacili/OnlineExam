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
    public class OpenExamsCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenExamsCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel; 
        }

        public override void Execute(object parameter)
        {
            List<ExamModel> examModels = new List<ExamModel>();
           //SubjectMapper mapper = new SubjectMapper();

            //for (int i = 0; i < subjects.Count; i++)
            //{
            //    Subject subject = subjects[i];
            //    SubjectModel model = mapper.Map(subject);
            //    model.No = i + 1;
            //    subjectModels.Add(model);
            //}
           EnumerationUtil.Enumerate(examModels);

            ExamsViewModel examsViewModel = new ExamsViewModel();


            examsViewModel.AllExams = examModels;

            ExamsControl examsControl = new ExamsControl();

            examsControl.DataContext = examsViewModel;
            examsViewModel.Exams = new ObservableCollection<ExamModel>(examModels);

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;

            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(examsControl);
        }
    }
}
