using Microsoft.AspNetCore.Mvc;
using OnlineExamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            SubjectModel subjectModel = new SubjectModel();
            subjectModel.Name = "Azerbaijan";
            return View(subjectModel);
        }
    }
}
