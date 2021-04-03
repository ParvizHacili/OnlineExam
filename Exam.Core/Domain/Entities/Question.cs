using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public class Question :BaseEntity
    {
        public Exam Exam { get; set; }
        public string Questionn { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string TrueAnswer { get; set; }
    }
}
