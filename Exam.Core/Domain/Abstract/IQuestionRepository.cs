using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
   public interface  IQuestionRepository
    {
        int Add(Question question);
        List<Question> Get();
        bool Update(Question question);
        List<Question>GetByID(int ID);
    }
}
