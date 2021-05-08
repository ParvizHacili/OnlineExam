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
            if (examModel == null)
                return null;

            Exam1 exam = new Exam1();
            exam.ID = examModel.ID;
            exam.ExamType = examModel.ExamType;
            exam.Note = examModel.Note;

            return exam;
        }

        public override ExamModel Map(Exam1 exam)
        {
            if (exam == null)
                return null;

            ExamModel examModel = new ExamModel();
            examModel.ID = exam.ID;
            examModel.ExamType = exam.ExamType;
            examModel.Note = exam.Note;

            return examModel;
        }
    }
}
