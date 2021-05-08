using Exam.Core.Domain.Entities;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Mappers
{
    public class QuestionMapper : BaseMapper<Question, QuestionModel>
    {
        public override Question Map(QuestionModel questionModel)
        {
            if (questionModel == null)
                return null;

            ExamMapper examMapper = new ExamMapper();
            SubjectMapper subjectMapper = new SubjectMapper();

            Question question = new Question()
            {
                ID = questionModel.ID,
                Questionn = questionModel.Question,
                VariantA = questionModel.VariantA,
                VariantB = questionModel.VariantB,
                VariantC = questionModel.VariantC,
                VariantD = questionModel.VariantD,
                VariantE = questionModel.VariantE,
                TrueAnswer = questionModel.TrueAnswer,
            };

            question.Exam = examMapper.Map(questionModel.Exam);
            question.Subject = subjectMapper.Map(questionModel.Subject);
            return question;
        }

        public override QuestionModel Map(Question question)
        {
            if (question == null)
                return null;

            ExamMapper examMapper = new ExamMapper();
            SubjectMapper subjectMapper = new SubjectMapper();

            QuestionModel questionModel = new QuestionModel()
            {
                ID = question.ID,
                Question = question.Questionn,
                VariantA = question.VariantA,
                VariantB = question.VariantB,
                VariantC = question.VariantC,
                VariantD = question.VariantD,
                VariantE = question.VariantE,
                TrueAnswer=question.TrueAnswer
            };
            questionModel.Exam = examMapper.Map(question.Exam);
            questionModel.Subject = subjectMapper.Map(question.Subject);
            return questionModel;
        }
    }
}
