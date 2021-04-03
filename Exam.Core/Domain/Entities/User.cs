using Exam.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Entities
{
    public  class User :BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Password { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }        
        public bool CanOperateCrm { get; set; }
        public Enums.Type Type { get; set; }
    }
}
