using Exam.Core;
using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineExamUI.Helpers;
using OnlineExamWeb.Mappers;
using OnlineExamWeb.Models;
using OnlineExamWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            //EnumerationUtil.Enumerate(subjectViewModel.Subjects); // qaldi

            return View(subjectViewModel);
        }
    }
}
