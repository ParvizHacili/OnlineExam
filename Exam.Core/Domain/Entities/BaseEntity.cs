using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public User Creator { get; set; }
    }
       
}
