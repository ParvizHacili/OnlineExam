using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.Enums;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OnlineExamUI.Commands.Questions
{
    public  class SaveQuestionCommand :BaseQuestionCommand
    {
        public SaveQuestionCommand(QuestionsViewModel viewmodel) : base(viewmodel)
        {

        }

        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if (viewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
            }
            else
            {
                if (viewModel.CurrentSituation == (int)Situation.ADD || viewModel.CurrentSituation == (int)Situation.EDIT)
                {
                    QuestionMapper mapper = new QuestionMapper();
                    Question question = mapper.Map(viewModel.CurrentQuestion);

                    question.Creator = Kernel.CurrentUser;
                    if (viewModel.CurrentQuestion.No == 0)
                    {
                        viewModel.CurrentQuestion.ID = DB.QuestionRepository.Add(question);
                        viewModel.CurrentQuestion.No = viewModel.Questions.Count + 1;
                        viewModel.Questions.Add(viewModel.CurrentQuestion);
                    }
                    else
                    {
                        DB.QuestionRepository.Update(question);
                        viewModel.Questions[viewModel.CurrentQuestion.No - 1] = viewModel.CurrentQuestion;
                    }

                    viewModel.SelectedQuestion = null;
                    viewModel.CurrentQuestion = new QuestionModel();

                    viewModel.CurrentSituation = (int)Situation.NORMAL;
                }
                else
                {
                    //MessageBox.Show(UIMessages.ValidationCommonMessage, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

      }

    }

