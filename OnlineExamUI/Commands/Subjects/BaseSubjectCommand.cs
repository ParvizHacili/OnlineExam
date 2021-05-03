using Exam.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Subjects
{
    public abstract class BaseSubjectCommand : BaseCommand
    {
        protected readonly SubjectsViewModel viewModel;
        public BaseSubjectCommand(SubjectsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
