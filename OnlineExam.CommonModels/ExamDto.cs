using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.CommonModels
{
    public class ExamDto :BaseDto
    {
        public string ExamType { get; set; }

        public string Note { get; set; }
    }
}
