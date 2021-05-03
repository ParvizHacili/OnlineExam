using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlExamRepository : SqlBaseRepository, IExamRepository
    {
        public SqlExamRepository(SqlContext context) : base(context)
        {

        }
        public int Add(Exam1 exam)
        {
            using(SqlConnection connection=new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Exams output inserted.ID values(@SubjectsID,
                    @Note,@LastModifiedDate,@CreatorID,@IsDeleted,@ExamType)";
                using(SqlCommand command =new SqlCommand(cmdText,connection))
                {
                    AddParameters(command, exam);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public List<Exam1> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Exam1 exam)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Update Exams set SubjectsID=@SubjectsID,Note=@Note,
                    LastModifiedDate=@LastModifiedDate,CreatorID=@CreatorID,
                    IsDeleted=@IsDeleted,
                    ExamType=@Examtype where ID=@ID";
                using(SqlCommand command =new SqlCommand(cmdText,connection))
                {
                    command.Parameters.AddWithValue("@ID", exam.ID);
                    
                    AddParameters(command, exam);

                    return command.ExecuteNonQuery() == 1;
                }
            }

        }

        private void AddParameters(SqlCommand command,Exam1 exam)
        {
            command.Parameters.AddWithValue("@SubjectsID", exam.Subject.ID);
            command.Parameters.AddWithValue("@Note", exam.Note ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastModifiedDate", exam.LastModifiedDate);
            command.Parameters.AddWithValue("@CreatorID", exam.Creator.ID);
            command.Parameters.AddWithValue("@IsDeleted", exam.IsDeleted);
            command.Parameters.AddWithValue("@ExamType", exam.ExamType ?? (object)DBNull.Value);
        }
    }
}
