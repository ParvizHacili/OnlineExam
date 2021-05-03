using Exam.Core.Domain.Entities;
using Exam.ViewModels.UserControls;
using OnlineExamUI.Commands.Exams;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.UserControls
{
    public class ExamsViewModel : BaseControlViewModel
    {
        public ExamsViewModel()
        {

        }
        public override string Header => "İmtahanlar";

        private List<ExamModel> allExams;
        public List<ExamModel> AllExams
        {
            get => allExams;
            set
            {
                allExams = value;
                OnPropertyChanged(nameof(AllExams));
            }
        }

        private ObservableCollection<ExamModel> exams;
        public ObservableCollection<ExamModel>Exams
        {
            get => exams;
            set
            {
                exams = value;
                OnPropertyChanged(nameof(Exam));
            }
        }

        private ExamModel currentExam;
        public ExamModel CurrentExam 
        {
            get => currentExam;
            set
            {
                currentExam = value;
                OnPropertyChanged(nameof(CurrentExam));
            }
        }

        private ExamModel selectedExam;
        public ExamModel SelectedExam
        {
            get => selectedExam;
            set
            {
                selectedExam = value;
                OnPropertyChanged(nameof(SelectedExam));
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
            }
        }

        #region commands
        public SaveExamCommand Save => new SaveExamCommand(this);

        public RejectExamCommand Reject => new RejectExamCommand(this);

        public DeleteExamCommand Delete => new DeleteExamCommand(this);

        public ExcelExporterExamCommand ExportExcel => new ExcelExporterExamCommand(this);
        #endregion

    }
}
