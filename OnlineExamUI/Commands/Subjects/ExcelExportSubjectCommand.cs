using ClosedXML.Excel;
using Exam.ViewModels.UserControls;
using Microsoft.Win32;
using OnlineExamUI.Helpers;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OnlineExamUI.Commands.Subjects
{
    public class ExcelExportSubjectCommand : BaseSubjectCommand
    {
        public ExcelExportSubjectCommand(SubjectsViewModel viewModel):base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(viewModel.Subjects);
        }
    }
}
