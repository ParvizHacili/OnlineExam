using OnlineExamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.ViewModels
{
    public class ExamViewModel
    {
        public List<ExamModel> Exams { get; set; } = new List<ExamModel>();

        public int DeletedID { get; set; }
    }
}
