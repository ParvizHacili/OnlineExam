using Exam.Core.Domain.Entities;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Mappers
{
    public class SubjectMapper : BaseMapper<Subject, SubjectModel>
    {
        public override Subject Map(SubjectModel subjectModel)
        {
            Subject subject = new Subject();
            
            subject.Name = subjectModel.Name;
            subject.ID = subjectModel.ID;

            return subject;
        }

        public override SubjectModel Map(Subject subject)
        {
            SubjectModel subjectModel = new SubjectModel();
            subjectModel.Name = subject.Name;
            subjectModel.ID = subject.ID;

            return subjectModel;
        }
    }
}
