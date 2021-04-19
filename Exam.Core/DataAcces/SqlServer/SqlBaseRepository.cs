using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public abstract class SqlBaseRepository
    {
        protected readonly SqlContext context;
        public SqlBaseRepository(SqlContext context)
        {
            this.context = context;
        }
    }
}
