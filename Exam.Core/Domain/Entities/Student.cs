using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
     public class Student :BaseEntity
    {
        public User User { get; set; }
        public School School { get; set; }
    }
}
