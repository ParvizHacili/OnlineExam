using OnlineExamUI.Commands.Subjects;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private SubjectModel selectedSubject;
        public SubjectModel SelectedSubject
        {
            get => selectedSubject;
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));

                CurrentSubject = SelectedSubject?.Clone();
                        
                if(SelectedSubject!=null)
                {
                    CurrentSituation = (int)Situation.SELECTED;
                }
                

            }
        }


        private ObservableCollection<SubjectModel> _subjects;
        public ObservableCollection<SubjectModel> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        #endregion

        #region Commands

        public SaveSubjectCommand Save => new SaveSubjectCommand(this);

        public RejectSubjectCommand Reject => new RejectSubjectCommand(this);

        public DeleteSubjectCommand Delete => new DeleteSubjectCommand(this);

        #endregion

        #region private methods

       

        #endregion
    }
}
