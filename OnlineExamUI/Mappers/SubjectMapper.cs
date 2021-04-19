using Exam.Core.Domain.Entities;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Mappers
{
    public class SubjectMapper : BaseMapper<Subject, SubjectModel>
    {
        public override Subject Create(SubjectModel subjectModel)
        {
            Subject subject = new Subject();
            subject.Name = subjectModel.Name;

            return subject;
        }

        public override SubjectModel Create(Subject subject)
        {
            SubjectModel subjectModel = new SubjectModel();
            subjectModel.Name = subject.Name;

            return subjectModel;
        }
    }
}
