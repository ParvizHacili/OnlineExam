using OnlineExamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.ViewModels
{
    public class QuestionViewModel
    {
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();

        public int DeletedID { get; set; }
    }
}
