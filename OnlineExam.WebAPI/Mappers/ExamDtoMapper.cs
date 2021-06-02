using Exam.Core.Domain.Entities;
using OnlineExam.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.WebAPI.Mappers
{
    public class ExamDtoMapper
    {
        public ExamDto Map(Exam1 exam)
        {
            return new ExamDto()
            {
                ID = exam.ID,
                ExamType = exam.ExamType,
                Note = exam.Note
            };
        }

        public Exam1 Map(ExamDto examDto)
        {
            return new Exam1()
            {
                ID = examDto.ID,
                ExamType = examDto.ExamType,
                Note = examDto.Note
            };

        }
    }
}
