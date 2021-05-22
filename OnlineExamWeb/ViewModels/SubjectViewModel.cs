using OnlineExamWeb.Models;
using System.Collections.Generic;

namespace OnlineExamWeb.ViewModels
{
    public class SubjectViewModel
    {
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public int DeletedID { get; set; }
    }
}
