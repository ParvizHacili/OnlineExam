using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlSubjectRepository : SqlBaseRepository, ISubjectRepository
    {
        public SqlSubjectRepository(SqlContext context) : base(context)
        {

        }
        public int Add(Subject subject)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdtext = @"Insert into Subjects  output inserted.ID values
                                (@Name,@LastModifiedDate,@CreatorID,@IsDeleted) ";

                using (SqlCommand command = new SqlCommand(cmdtext, connection))
                {
                    command.Parameters.AddWithValue("@Name", subject.Name);
                    command.Parameters.AddWithValue("@LastModifiedDate", subject.LastModifiedDate);
                    command.Parameters.AddWithValue("@CreatorID", subject.Creator.ID);
                    command.Parameters.AddWithValue("@IsDeleted", subject.IsDeleted);

                    return (int)command.ExecuteScalar();

                }
            }
        }
    }
}
