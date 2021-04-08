using Exam.Core.DataAcces.SqlServer;
using Exam.Core.Domain.Abstract;
using Exam.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Create(ServerType serverType, string connectionString)
        {
            switch (serverType)
            {
                case ServerType.SqlServer:
                    {

                        return new SqlUnitOfWork(connectionString);

                    }
                default:
                    {
                        throw new NotSupportedException($"{serverType} not supported");
                    }

            }
        }


    }
}
