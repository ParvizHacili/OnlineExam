using OnlineExamUI.Helpers;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Questions
{
    public class ExcelExporterQuestionCommand : BaseQuestionCommand
    {
        public ExcelExporterQuestionCommand(QuestionsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(viewModel.Questions);
        }
    }
}
