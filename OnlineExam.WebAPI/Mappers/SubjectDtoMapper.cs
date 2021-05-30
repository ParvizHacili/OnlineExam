using Exam.Core.Domain.Entities;
using OnlineExam.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.WebAPI.Mappers
{
    public class SubjectDtoMapper
    {
        public SubjectDto Map(Subject subject)
        {
            return new SubjectDto()
            {
                ID = subject.ID,
                Name = subject.Name,
            };
        }

        public Subject Map(SubjectDto subjectDto)
        {
            return new Subject()
            {
                ID = subjectDto.ID,
                Name = subjectDto.Name,
            };
        }
    }
}
