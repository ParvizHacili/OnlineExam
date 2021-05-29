using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public class UserRole
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
