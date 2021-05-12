using OnlineExamUI.Commands.OnlineExams;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using OnlineExamUI.Views.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.UserControls
{
   public  class OnlineExamsViewModel : BaseControlViewModel
    {
        public OnlineExamsViewModel()
        {

        }

        public override string Header => "Onlayn İmtahan";

        private int currentQuestion;
        public int CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;

                var currentQuestionControl = QuestionControls[currentQuestion];

                SingleQuestionPanel.Children.Clear();
                SingleQuestionPanel.Children.Add(currentQuestionControl);
            }
        }

        public List<SingleQuestionControl> QuestionControls = new List<SingleQuestionControl>();

        public Grid SingleQuestionPanel;

        #region commads
        public StartOnlineExamCommand Start => new StartOnlineExamCommand(this);
        public FinishOnlineExamCommand Finish => new FinishOnlineExamCommand(this);

        #endregion
    }
}
