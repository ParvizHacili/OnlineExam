using Exam.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
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

        public IUserRepository UserRepository => new SqlUserRepository(context);
    }
}
