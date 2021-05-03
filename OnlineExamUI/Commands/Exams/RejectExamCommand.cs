using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Exams
{
    public class RejectExamCommand : BaseExamCommand
    {
        public RejectExamCommand(ExamsViewModel viewModel) :base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.CurrentExam = null;
            viewModel.CurrentExam = new ExamModel();
            viewModel.CurrentSituation = (int)Situation.NORMAL;
        }
    }
}
