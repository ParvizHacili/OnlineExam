using OnlineExamUI.Commands.MainPage;
using System;
using System.Collections.Generic;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.Windows
{
    public class MainViewModel : BaseWindowViewModel
    {
        public OpenSubjectsCommand OpenSubjects => new OpenSubjectsCommand(this);

    }
}
