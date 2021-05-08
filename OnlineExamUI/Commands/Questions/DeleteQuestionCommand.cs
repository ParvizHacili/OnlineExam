using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.Enums;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineExamUI.Commands.Questions
{
   public class DeleteQuestionCommand :BaseQuestionCommand
    {
        public DeleteQuestionCommand(QuestionsViewModel viewmodel) : base(viewmodel)
        {

        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            sureDialogViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog sureDialog = new SureDialog();
            sureDialog.DataContext = sureDialogViewModel;
            sureDialog.ShowDialog();

            if(sureDialog.DialogResult==true)
            {
                QuestionMapper questionMapper = new QuestionMapper();

                Question question = questionMapper.Map(viewModel.CurrentQuestion);
                question.IsDeleted = true;
                question.Creator = Kernel.CurrentUser;

                DB.QuestionRepository.Update(question);

                int no = viewModel.SelectedQuestion.No;

                viewModel.CurrentSituation = (int)Situation.NORMAL;
                viewModel.Questions.Remove(viewModel.SelectedQuestion);

                List<QuestionModel> modelList = viewModel.Questions.ToList();

                EnumerationUtil.Enumerate(modelList, no - 1);
                viewModel.AllQuestions = modelList;

                //viewModel.updatedatafiltered

                viewModel.SelectedQuestion = null;
                viewModel.CurrentQuestion = new QuestionModel();
            }
        }
    }
}
