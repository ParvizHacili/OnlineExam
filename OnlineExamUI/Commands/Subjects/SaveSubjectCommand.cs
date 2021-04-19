using Exam.Core;
using Exam.Core.Domain.Entities;
using Exam.ViewModels.UserControls;
using OnlineExamUI.Enums;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Subjects
{
    public class SaveSubjectCommand : BaseSubjectCommand
    {
        public SaveSubjectCommand(SubjectsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else
            {
                if ((viewModel.CurrentSituation == (int)Situation.ADD) || viewModel.CurrentSituation == (int)Situation.EDIT)
                {
                    SubjectMapper subjectMapper = new SubjectMapper();
                    Subject subject = subjectMapper.Create(viewModel.CurrentSubject);

                    subject.Creator = Kernel.CurrentUser;

                    DB.SubjectRepository.Add(subject);

                    viewModel.CurrentSituation = (int)Situation.NORMAL;

                    viewModel.CurrentSubject = new SubjectModel();

                }
            }
        }
    }
}
