using OnlineExamUI.Commands.OnlineExams;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.UserControls
{
   public  class OnlineExamsViewModel : BaseControlViewModel
    {
        public OnlineExamsViewModel()
        {

        }
        public override string Header => "Onlayn İmtahan";


        #region commads
        public StartOnlineExamCommand Start => new StartOnlineExamCommand(this);
        public FinishOnlineExamCommand Finish => new FinishOnlineExamCommand(this);

        #endregion
       
    }
}
