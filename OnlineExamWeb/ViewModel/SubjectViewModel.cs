using OnlineExamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.ViewModel
{
    public class SubjectViewModel
    {
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public int DeletedID { get; set; }
    }
}
