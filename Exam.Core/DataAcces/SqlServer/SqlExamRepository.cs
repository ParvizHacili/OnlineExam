using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Extensions;

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

                string cmdText = @"Insert into Exams output inserted.ID values(
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
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdtext = @"select * from Exams where IsDeleted=0";
                
                using (SqlCommand command = new SqlCommand(cmdtext, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<Exam1> exams = new List<Exam1>();

                    while (reader.Read())
                    {
                        Exam1 exam = new Exam1();
                        exam.ID = reader.GetInt32("ID");

                        exam.ExamType = reader.GetString("ExamType");

                        if (reader["Note"] != DBNull.Value)
                        {
                            exam.Note = (string)reader["Note"];
                        }
                        if (!reader.IsDBNull("CreatorID"))
                        {
                            exam.Creator = new User()
                            {
                                ID = reader.GetInt32("ID")
                            };
                        }
                        exam.LastModifiedDate = reader.GetDateTime("LastModifiedDate");
                        exam.IsDeleted = reader.GetBoolean("IsDeleted");


                        exams.Add(exam);
                 }
                    return exams;
                }
            }
        }

        public bool Update(Exam1 exam)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Update Exams set Note=@Note,
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
            command.Parameters.AddWithValue("@Note", exam.Note ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastModifiedDate", exam.LastModifiedDate);
            command.Parameters.AddWithValue("@CreatorID", exam.Creator.ID);
            command.Parameters.AddWithValue("@IsDeleted", exam.IsDeleted);
            command.Parameters.AddWithValue("@ExamType", exam.ExamType ?? (object)DBNull.Value);
        }

        //private Exam1 GetFromReader(SqlDataReader reader)
        //{
        //    Exam1 exam = new Exam1();

      
        //    return exam;
        //}
    }
}
