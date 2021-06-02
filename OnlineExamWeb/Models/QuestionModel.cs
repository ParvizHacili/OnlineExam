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

        [Required(ErrorMessage ="Sual mütləq daxil edilməlidir!")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Variant mütləq daxil edilməlidir!")]
        public string VariantA { get; set; }

        [Required(ErrorMessage = "Variant mütləq daxil edilməlidir!")]
        public string VariantB { get; set; }

        [Required(ErrorMessage = "Variant mütləq daxil edilməlidir!")]
        public string VariantC { get; set; }

        [Required(ErrorMessage = "Variant mütləq daxil edilməlidir!")]
        public string VariantD { get; set; }

        [Required(ErrorMessage = "Variant mütləq daxil edilməlidir!")]
        public string VariantE { get; set; }

        [Required(ErrorMessage = "Düzgün avab variantı mütləq daxil edilməlidir!")]
        public string TrueAnswer { get; set; }

        public List<SelectListItem> Subjects;
        public List<SelectListItem> Exams;
    }
}
