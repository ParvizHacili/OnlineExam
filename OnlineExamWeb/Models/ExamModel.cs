using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Models
{
    public class ExamModel :BaseModel
    {
        public string ExamType { get; set; }

        public string Note { get; set; }
    }
}
