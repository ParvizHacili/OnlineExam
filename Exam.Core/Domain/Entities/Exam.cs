using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public  class Exam :BaseEntity
    {
        public Subject Subject { get; set; }
        public Type Type { get; set; }
        public string Note { get; set; }
    }
}
