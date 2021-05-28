using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public class QuestionModel :BaseModel
    {
        [Required]
        public ExamModel Exam { get; set; }

        [Required]
        public SubjectModel Subject { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string VariantA { get; set; }

        [Required]
        public string VariantB { get; set; }

        [Required]
        public string VariantC { get; set; }

        [Required]
        public string VariantD { get; set; }

        [Required]
        public string VariantE { get; set; }

        [Required]
        public string TrueAnswer { get; set; }

        public List<SelectListItem> Subjects;
        public List<SelectListItem> Exams;
    }
}
