using Exam.ViewModels.UserControls;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Subjects
{
    public class RejectSubjectCommand : BaseSubjectCommand
    {
        public RejectSubjectCommand(SubjectsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.SelectedSubject = null;
            viewModel.CurrentSubject = new SubjectModel();
            viewModel.CurrentSituation = (int)Situation.NORMAL;
        }
    }
}
