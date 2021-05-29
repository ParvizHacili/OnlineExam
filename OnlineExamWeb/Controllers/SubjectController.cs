﻿using Exam.Core;
using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamUI.Helpers;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.Models;
using OnlineExamWeb.ViewModels;
using System.Collections.Generic;

namespace OnlineExamWeb.Controllers
{
    [Authorize(Roles="SA,A")]
    public class SubjectController : BaseController
    {
        public SubjectController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }

        string message = "Əməliyyat uğurla həyata keçdi!";

        [AllowAnonymous] ///
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            List<Subject> subjects = DB.SubjectRepository.Get();

            SubjectViewModel subjectViewModel = new SubjectViewModel();

            SubjectMapper subjectMapper = new SubjectMapper();

            foreach(var subject in subjects)
            {
                var subjectModel = subjectMapper.Map(subject);
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
            return View(new SubjectModel());
        }

        [HttpPost]
        public IActionResult SaveSubject(SubjectModel subjectModel)
        {
            if(!ModelState.IsValid)
            {
                return Content("Məlumatlar düzgün daxil edilməyib");
            }
            SubjectMapper subjectMapper = new SubjectMapper();
            Subject subject = subjectMapper.Map(subjectModel);
            subject.Creator = CurrentUser;

            if(subject.ID!=0)
            {
                DB.SubjectRepository.Update(subject);
                TempData["Message"] = message;
            }
            else
            {
                DB.SubjectRepository.Add(subject);
            }

            TempData["Message"] = message;
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

            subject.Creator = CurrentUser; 
            subject.IsDeleted = true;

            DB.SubjectRepository.Update(subject);

            TempData["Message"] = message;
            return RedirectToAction("Index");
        }
    }
}
