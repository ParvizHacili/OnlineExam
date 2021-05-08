using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Questions
{
    public class RejectQuestionCommand : BaseQuestionCommand
    {
        public RejectQuestionCommand(QuestionsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.SelectedQuestion = null;
            viewModel.CurrentQuestion = new QuestionModel();

            viewModel.CurrentSituation = (int)Situation.NORMAL;
        }
    }
}
