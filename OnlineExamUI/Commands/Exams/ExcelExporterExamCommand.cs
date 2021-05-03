using OnlineExamUI.Helpers;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Exams
{
    public class ExcelExporterExamCommand : BaseExamCommand
    {
        public ExcelExporterExamCommand(ExamsViewModel viewModel) :base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(viewModel.Exams);
        }
    }
}
