using Exam.Core.Domain.Entities;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Mappers
{
    public class ExamMapper : BaseMapper<Exam1, ExamModel>
    {
        public override Exam1 Map(ExamModel examModel)
        {
            Exam1 exam = new Exam1();
            exam.Subject.ID = examModel.SubjectModel.ID;
            exam.ExamType = examModel.ExamType;
            exam.Note = examModel.Note;

            return exam;
        }

        public override ExamModel Map(Exam1 exam)
        {
            ExamModel examModel = new ExamModel();
            examModel.SubjectModel.ID = exam.Subject.ID;
            examModel.ExamType = exam.ExamType;
            examModel.Note = exam.Note;

            return examModel;
        }
    }
}
