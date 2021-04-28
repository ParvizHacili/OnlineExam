using Exam.Core;
using Exam.Core.Domain.Entities;
using Exam.ViewModels.UserControls;
using OnlineExamUI.Enums;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.Windows;
using OnlineExamUI.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OnlineExamUI.Commands.Subjects
{
    public class DeleteSubjectCommand : BaseSubjectCommand
    {
        public DeleteSubjectCommand(SubjectsViewModel viewmodel) : base(viewmodel)
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
                SubjectMapper mapper = new SubjectMapper();

                Subject subject = mapper.Map(viewModel.CurrentSubject);
                subject.IsDeleted = true;
                subject.Creator = Kernel.CurrentUser;

                DB.SubjectRepository.Update(subject);

                int no = viewModel.SelectedSubject.No;

                viewModel.CurrentSituation = (int)Situation.NORMAL;
                viewModel.Subjects.Remove(viewModel.SelectedSubject);

                List<SubjectModel> modelList = viewModel.Subjects.ToList();
                EnumerationUtil.Enumerate(modelList, no - 1);
                viewModel.AllSubjects = modelList;
                viewModel.UpdateDataFiltered();

                viewModel.SelectedSubject = null;
                viewModel.CurrentSubject = new SubjectModel();
            }
        }
    }
}
