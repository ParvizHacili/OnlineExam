using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamWeb.Helpers;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.Models;
using OnlineExamWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Controllers
{
    [Authorize(Roles = "SA,A")]
    public class ExamController : BaseController
    {
        public ExamController (IUnitOfWork db,UserManager<User> userManager) : base(db, userManager) { }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

            List<Exam1> exams = DB.ExamRepository.Get();
            ExamViewModel examViewModel = new ExamViewModel();
            ExamMapper examMapper = new ExamMapper();

            foreach(var exam in exams)
            {
                var examModel = examMapper.Map(exam);
                examViewModel.Exams.Add(examModel);
            }
            EnumerationUtil.Enumerate(examViewModel.Exams);

            return View(examViewModel);
        }

        [HttpGet]
        public IActionResult SaveExam(int ID)
        {
            if(ID!=0)
            {
                Exam1 exam = DB.ExamRepository.Get(ID);

                if(exam==null)
                {
                    return Content("İmtahan növü tapılmadı");
                }
                ExamMapper examMapper = new ExamMapper();
                ExamModel examModel = examMapper.Map(exam);

                return View(examModel);
            }
            return View(new ExamModel());
        }

        
        [HttpPost]
        public IActionResult SaveExam(ExamModel examModel)
        {
            if (!ModelState.IsValid)
            {
                return Content(UiMessages.WrongMessage);
            }

            ExamMapper examMapper = new ExamMapper();
            Exam1 exam = examMapper.Map(examModel);
            exam.Creator = CurrentUser;

            if(exam.ID!=0)
            {
                DB.ExamRepository.Update(exam);
                TempData["Message"] = UiMessages.SuccesMessage;
            }
            else
            {
                DB.ExamRepository.Add(exam);
                TempData["Message"] = UiMessages.SuccesMessage;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete (ExamViewModel examViewModel)
        {
            Exam1 exam = DB.ExamRepository.Get(examViewModel.DeletedID);

            if(exam==null)
            {
                return Content("İmtahan növü tapılmadı");
            }

            exam.Creator = CurrentUser;
            exam.IsDeleted = true;

            DB.ExamRepository.Update(exam);

            TempData["Message"] = UiMessages.SuccesMessage;

            return RedirectToAction("Index");
        }
    }
}
