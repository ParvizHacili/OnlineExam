using Exam.ViewModels.UserControls;
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
            throw new NotImplementedException();
        }
    }
}
