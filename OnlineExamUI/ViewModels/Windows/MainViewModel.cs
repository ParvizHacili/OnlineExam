using OnlineExamUI.Commands;
using OnlineExamUI.Commands.MainPage;
using System;
using System.Collections.Generic;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.Windows
{
    public class MainViewModel : BaseWindowViewModel
    {
        public ReturnMainMenuCommand ReturnMainWindow => new ReturnMainMenuCommand(this);
        public OpenSubjectsCommand OpenSubjects => new OpenSubjectsCommand(this);
        public OpenExamsCommand OpenExams => new OpenExamsCommand(this);
        public OpenUsersCommand OpenUsers => new OpenUsersCommand(this);
        public OpenQuestionsCommand OpenQuestions => new OpenQuestionsCommand(this);
        public OpenOnlineExamCommand OpenOnlineExam => new OpenOnlineExamCommand(this);
    }
}
