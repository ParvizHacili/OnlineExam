using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.ViewModels;
using OnlineExamUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Controllers
{
    public class QuestionController : BaseController
    {
        public QuestionController(IUnitOfWork db) : base(db) { }

        public IActionResult Index()
        {
            List<Question> questions = DB.QuestionRepository.Get();

            QuestionViewModel questionViewModel = new QuestionViewModel();

            QuestionMapper questionMapper = new QuestionMapper();

            foreach (var question in questions)
            {
                var questionModel = questionMapper.Map(question);
                questionViewModel.Questions.Add(questionModel);
            }

            EnumerationUtil.Enumerate(questionViewModel.Questions);

            return View(questionViewModel);

            //error
        }
    }
}
