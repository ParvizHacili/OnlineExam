using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public class QuestionModel :BaseModel
    {
        public ExamModel Exam { get; set; }

        public SubjectModel Subject { get; set; }

        public string Question { get; set; }

        public string VariantA { get; set; }

        public string VariantB { get; set; }

        public string VariantC { get; set; }

        public string VariantD { get; set; }

        public string VariantE { get; set; }

        public string TrueAnswer { get; set; }
    }
}
