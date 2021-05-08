using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        bool CheckServer();
        public IUserRepository UserRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IExamRepository ExamRepository { get; } 
        public IQuestionRepository QuestionRepository { get; }
    }
}
