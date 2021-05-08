using OnlineExamUI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Models
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


        public QuestionModel Clone()
        {

            return new QuestionModel()
            {
                ID = ID,
                No = No,
                Subject = Subject?.Clone(),
                Exam = Exam?.Clone(),
                Question = Question,
                VariantA = VariantA,
                VariantB = VariantB,
                VariantC = VariantC,
                VariantD = VariantD,
                VariantE = VariantE,
                TrueAnswer=TrueAnswer
         
            };
        }
    }
}
