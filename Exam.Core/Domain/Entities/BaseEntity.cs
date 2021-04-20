using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public User Creator { get; set; }
    }
       
}
