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
    public class OpenQuestionsCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenQuestionsCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            QuestionsViewModel questionsViewModel = new QuestionsViewModel();

            List<QuestionModel> questionModels = DataProvider.GetQuestions();
            EnumerationUtil.Enumerate(questionModels);

            questionsViewModel.Exams = DataProvider.GetExams();
            questionsViewModel.Subjects = DataProvider.GetSubjects();
            questionsViewModel.AllQuestions = questionModels;
            questionsViewModel.Questions = new ObservableCollection<QuestionModel>(questionModels);
            questionsViewModel.CurrentQuestion = new QuestionModel();

            QuestionsControl questionsControl = new QuestionsControl();

            questionsControl.DataContext = questionsViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(questionsControl);
        }
    }
}
