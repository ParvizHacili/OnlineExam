using Exam.Core.Domain.Entities;
using OnlineExamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Mappers
{
    public class SubjectMapper :BaseMapper<Subject,SubjectModel>
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
