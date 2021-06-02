using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
   public interface  IExamRepository
    {
        int Add(Exam1 exam);
        bool Update(Exam1 exam);
        List<Exam1> Get();
        Exam1 Get(int ID);
    }
}
