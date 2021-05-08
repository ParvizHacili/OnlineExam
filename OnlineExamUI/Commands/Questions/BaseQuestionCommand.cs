using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Questions
{
    public abstract class BaseQuestionCommand : BaseCommand
    {
        protected readonly QuestionsViewModel viewModel;
        public BaseQuestionCommand(QuestionsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
