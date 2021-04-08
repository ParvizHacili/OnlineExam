using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlContext
    {
        public SqlContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
