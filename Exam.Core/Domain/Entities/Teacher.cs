using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public  class Teacher :BaseEntity
    {
        public User User { get; set; }
    }
}
