using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public class Question :BaseEntity
    {
        public Exam1 Exam { get; set; }
        public Subject Subject { get; set; }

        public string Questionn { get; set; }
        public string VariantA { get; set; }
        public string VariantB { get; set; }
        public string VariantC { get; set; }
        public string VariantD { get; set; }
        public string VariantE { get; set; }
        public string TrueAnswer { get; set; }

    }
}
