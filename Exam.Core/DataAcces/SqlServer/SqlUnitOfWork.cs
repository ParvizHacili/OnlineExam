using Exam.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;
        public SqlUnitOfWork(string connectionString)
        {
            context = new SqlContext(connectionString);
        }

        public ISubjectRepository SubjectRepository => new SqlSubjectRepository(context);

        public IUserRepository UserRepository => new SqlUserRepository(context);

        public IExamRepository ExamRepository => new SqlExamRepository(context);

        public IQuestionRepository QuestionRepository => new SqlQuestionRepository(context);

        public bool CheckServer()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(context.ConnectionString))
                {
                    conn.Open();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
