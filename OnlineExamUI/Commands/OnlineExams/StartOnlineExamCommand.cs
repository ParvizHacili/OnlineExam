using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.Enums;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using OnlineExamUI.Views;
using OnlineExamUI.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace OnlineExamUI.Commands.OnlineExams
{
    public class StartOnlineExamCommand : BaseOnlineExamCommand
    {
        public StartOnlineExamCommand(OnlineExamsViewModel viewmodel) : base(viewmodel)
        {

        }

        public bool test = true;
        public override void Execute(object parameter)
        {
            if(test)
            {
                viewModel.CurrentQuestion++;
                test = false;
            }
            else
            {
                viewModel.CurrentQuestion--;
                test = true;
            }

            return;
            
            OnlineExamsViewModel onlineExamsViewModel = new OnlineExamsViewModel();
            ChooseExam chooseExam = new ChooseExam();

            QuestionsViewModel questionsViewModel = new QuestionsViewModel();

            questionsViewModel.Exams = DataProvider.GetExams();
            questionsViewModel.Subjects = DataProvider.GetSubjects();

            chooseExam.DataContext = questionsViewModel;
            chooseExam.ShowDialog();

            if (chooseExam.DialogResult == true)
            {
               //questionsViewModel.CurrentQuestion = DataProvider.GetQuestions();
            }

       }
    }
}
