using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public  class School :BaseEntity
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
