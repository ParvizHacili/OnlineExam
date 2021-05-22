using Exam.Core;
using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineExamUI.Helpers;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.Models;
using OnlineExamWeb.ViewModel;
using System.Collections.Generic;

namespace OnlineExamWeb.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork DB;
        public SubjectController(IUnitOfWork db)
        {
            DB = db;
        }

        public IActionResult Index()
        {
            List<Subject> subjects = DB.SubjectRepository.Get();

            SubjectViewModel subjectViewModel = new SubjectViewModel();

            SubjectMapper subjectMapper = new SubjectMapper();

            foreach(var subjec in subjects)
            {
                var subjectModel = subjectMapper.Map(subjec);
                subjectViewModel.Subjects.Add(subjectModel);
            }

            EnumerationUtil.Enumerate(subjectViewModel.Subjects);

            return View(subjectViewModel);
        }

        [HttpGet]
        public IActionResult SaveSubject(int ID)
        {
            if(ID!=0)
            {
                Subject subject = DB.SubjectRepository.Get(ID);

                if(subject==null)
                {
                    return Content("Fənn Tapılmadı");
                }

                SubjectMapper subjectMapper = new SubjectMapper();
                SubjectModel subjectModel = subjectMapper.Map(subject);

                return View(subjectModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult SaveSubject(SubjectModel subjectModel)
        {
            if(!ModelState.IsValid)
            {
                return Content("Məlmatlar düzgün daxil edilməyib");
            }
            SubjectMapper subjectMapper = new SubjectMapper();
            Subject subject = subjectMapper.Map(subjectModel);
            subject.Creator = Startup.CurrentUser;

            if(subject.ID!=0)
            {
                DB.SubjectRepository.Update(subject);

            }
            else
            {
                DB.SubjectRepository.Add(subject);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(SubjectViewModel subjectViewModel)
        {
            Subject subject = DB.SubjectRepository.Get(subjectViewModel.DeletedID);

            if (subject == null)
            {
                return Content("Fənn Tapılmadı");
            }

            subject.Creator = Startup.CurrentUser;
            subject.IsDeleted = true;

            DB.SubjectRepository.Update(subject);

            return RedirectToAction("Index");
        }
    }
}
