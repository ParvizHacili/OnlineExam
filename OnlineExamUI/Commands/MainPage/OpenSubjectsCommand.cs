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

            List<Subject> subjects = DB.SubjectRepository.Get();
            List<SubjectModel> subjectModels = new List<SubjectModel>();

            SubjectMapper mapper = new SubjectMapper();
            for(int i=0;i<subjects.Count;i++)
            {
                Subject subject = subjects[i];
               SubjectModel model= mapper.Map(subject);
                model.No = i + 1;
                subjectModels.Add(model);
            }
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
