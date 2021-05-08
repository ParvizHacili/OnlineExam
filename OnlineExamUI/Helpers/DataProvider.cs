using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Helpers
{
   public static class DataProvider
    {
        public static List<QuestionModel> GetQuestions()
        {
            List<Question> questions = Kernel.DB.QuestionRepository.Get();
            List<QuestionModel> questionModels = new List<QuestionModel>();
            QuestionMapper questionMapper = new QuestionMapper();

            foreach(var question in questions)
            {
                QuestionModel questionModel = questionMapper.Map(question);
                questionModels.Add(questionModel);
            }

            return questionModels;
        }


        public static List<ExamModel> GetExams()
        {
            List<Exam1> exams =Kernel.DB.ExamRepository.Get();
            List<ExamModel> examModels = new List<ExamModel>();
            ExamMapper mapper = new ExamMapper();
            foreach(var exam in exams)
            {
                ExamModel examModel = mapper.Map(exam);
                examModels.Add(examModel);
            }
            return examModels;
        }

        public static List<SubjectModel> GetSubjects()
        {
            List<Subject> subjects = Kernel.DB.SubjectRepository.Get();
            List<SubjectModel> subjectModels = new List<SubjectModel>();

            SubjectMapper mapper = new SubjectMapper();

            foreach (var subject in subjects)
            {
                SubjectModel subjectModel = mapper.Map(subject);
                subjectModels.Add(subjectModel);
            }

            //for (int i = 0; i < subjects.Count; i++)
            //{
            //    Subject subject = subjects[i];
            //    SubjectModel model = mapper.Map(subject);
            //    model.No = i + 1;
            //    subjectModels.Add(model);
            //}
            return subjectModels;
        }
    }
}
