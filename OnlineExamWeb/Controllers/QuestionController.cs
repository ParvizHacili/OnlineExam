using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.ViewModels;
using System.Collections.Generic;
using OnlineExamWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using OnlineExamWeb.Helpers;

namespace OnlineExamWeb.Controllers
{
    [Authorize(Roles = "SA,A")]
    public class QuestionController : BaseController
    {
        public QuestionController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

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

        }

        [HttpGet]
        public IActionResult SaveQuestion(int ID)
        {
            QuestionModel questionModel = new QuestionModel();


            if(ID!=0)
            {
                Question question = DB.QuestionRepository.FindByID(ID);
                if(question==null)
                {
                    return Content("Sual Tapılmadı");
                }
                QuestionMapper questionMapper = new QuestionMapper();
                questionModel = questionMapper.Map(question);
            }

            List<Subject> subjects = DB.SubjectRepository.Get();
            List<SelectListItem> subjectModels = new List<SelectListItem>();

            foreach (var subject in subjects)
            {
                subjectModels.Add(new SelectListItem(subject.Name, subject.ID.ToString()));
            }

            List<Exam1> exams = DB.ExamRepository.Get();
            List<SelectListItem> examModels = new List<SelectListItem>();

            foreach (var exam in exams)
            {
                examModels.Add(new SelectListItem(exam.ExamType, exam.ID.ToString()));
            }

            questionModel.Subjects = subjectModels;
            questionModel.Exams = examModels;

            return View(questionModel);
        }

        [HttpPost]
        public IActionResult SaveQuestion(QuestionModel questionModel)
        {
            //if (ModelState.IsValid == false)
            //{
            //    return Content("Model is invalid");
            //}

            //commentsiz error atir

            QuestionMapper questionMapper = new QuestionMapper();
            Question question = questionMapper.Map(questionModel);
            question.Creator = CurrentUser;

            if(question.ID !=0)
            {
                DB.QuestionRepository.Update(question);
                TempData["Message"] = UiMessages.SuccesMessage;
            }
            else
            {
                DB.QuestionRepository.Add(question);
                TempData["Message"] = UiMessages.SuccesMessage;

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(QuestionViewModel questionViewModel)
        {
            Question question = DB.QuestionRepository.FindByID(questionViewModel.DeletedID);

            if (question == null)
            {
                return Content("Sual Tapılmadı");
            }

            question.LastModifiedDate = DateTime.Now;
            question.IsDeleted = true;
            question.Creator = CurrentUser;

            DB.QuestionRepository.Update(question);

            TempData["Message"] = UiMessages.SuccesMessage;

            return RedirectToAction("Index");
        }
    }
}
