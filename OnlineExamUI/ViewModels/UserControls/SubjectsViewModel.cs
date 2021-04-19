using OnlineExamUI.Commands.Subjects;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace Exam.ViewModels.UserControls
{
    public class SubjectsViewModel : BaseControlViewModel
    {
        #region Properties
        public SubjectsViewModel()
        {

        }


        public override string Header => "Fənlər";

        private SubjectModel currentSubject = new SubjectModel();

        public SubjectModel CurrentSubject
        {
            get => currentSubject;

            set
            {
                currentSubject = value;
                OnPropertyChanged(nameof(CurrentSubject));
            }
        }
        #endregion

        #region Commands

        public SaveSubjectCommand Save => new SaveSubjectCommand(this);

        public RejectSubjectCommand Reject => new RejectSubjectCommand(this);

        public DeleteSubjectCommand Delete => new DeleteSubjectCommand(this);

        #endregion

    }
}
