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

namespace OnlineExamUI.Commands.Exams
{
   public  class DeleteExamCommand :BaseExamCommand
    {
        public DeleteExamCommand(ExamsViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel();
            sureViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();

            if (dialog.DialogResult == true)
            {
                ExamMapper mapper = new ExamMapper();

                Exam1 exam = mapper.Map(viewModel.CurrentExam);

                exam.IsDeleted = true;
                exam.Creator = Kernel.CurrentUser;

                DB.ExamRepository.Update(exam);

                int no = viewModel.SelectedExam.No;

                viewModel.CurrentSituation = (int)Situation.NORMAL;
                viewModel.Exams.Remove(viewModel.SelectedExam);

                List<ExamModel> modelList = viewModel.Exams.ToList();
                EnumerationUtil.Enumerate(modelList, no - 1);
                viewModel.AllExams = modelList;
                
                viewModel.UpdateDataFiltered();

                viewModel.SelectedExam = null;
                viewModel.CurrentExam = new ExamModel();
            }
        }   
    }
}
