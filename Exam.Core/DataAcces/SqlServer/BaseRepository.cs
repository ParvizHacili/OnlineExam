using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public abstract class BaseRepository
    {
        protected readonly SqlContext context;
        public BaseRepository(SqlContext context)
        {
            this.context = context;
        }
    }
}
