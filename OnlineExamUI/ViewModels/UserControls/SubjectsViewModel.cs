using OnlineExamUI.Commands.MainPage;
using OnlineExamUI.Commands.Subjects;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;
using System.Windows;
using OnlineExamUI.Views;
using OnlineExamUI.ViewModels;

namespace Exam.ViewModels.UserControls
{
    public class SubjectsViewModel : BaseControlViewModel
    {
        public SubjectsViewModel()
        {

        }
      
        #region Properties

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

        private List<SubjectModel> allSubjects;
        public List<SubjectModel> AllSubjects
        {
            get => allSubjects;
            set
            {
                allSubjects = value;
                OnPropertyChanged(nameof(AllSubjects));
            }
        }

        private ObservableCollection<SubjectModel> subjects;
        public ObservableCollection<SubjectModel> Subjects
        {
            get => subjects;
            set
            {
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateDataFiltered();           
            }
        }


        #endregion

        #region Commands

        public SaveSubjectCommand Save => new SaveSubjectCommand(this);

        public RejectSubjectCommand Reject => new RejectSubjectCommand(this);

        public DeleteSubjectCommand Delete => new DeleteSubjectCommand(this);

        public ExcelExportSubjectCommand ExportExcel => new ExcelExportSubjectCommand(this);

        public ReturnMainWindowCommand ReturnMainWindow => new ReturnMainWindowCommand(this);
       


        #endregion

        #region  methods

        public void UpdateDataFiltered()
        {
            List<SubjectModel> filteredSubjects = null;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredSubjects = AllSubjects;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();
                filteredSubjects = AllSubjects.Where(x => x.Name.ToLower().Contains(lowerSearchText)).ToList();
            }

            Subjects.Clear();
            foreach (var item in filteredSubjects)
            {
                Subjects.Add(item);
            }
        }


        #endregion
    }
}
