using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Extensions;
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
                    AddParameters(command, subject);
                    return (int)command.ExecuteScalar();

                }
            }
        }

        public List<Subject> Get()
        {
            using(SqlConnection connection=new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdtext = @"Select * from Subjects where IsDeleted=0";

                using (SqlCommand command = new SqlCommand(cmdtext,connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<Subject> subjects = new List<Subject>();

                    while (reader.Read())
                    {
                        Subject subject = GetFromReader(reader);
                        subjects.Add(subject);
                    }
                    return subjects;
                }
            }
        }

        public bool Update(Subject subject)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdtext = @"Update Subjects set Name=@Name,LastModifiedDate=@LastModifiedDate,
                                   CreatorID=@CreatorID,IsDeleted=@IsDeleted
                                   where ID=@ID ";

                using (SqlCommand command = new SqlCommand(cmdtext, connection))
                {
                    AddParameters(command, subject);
                    command.Parameters.AddWithValue("@ID", subject.ID);

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }


        private void AddParameters(SqlCommand command,Subject subject)
        {
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@LastModifiedDate", subject.LastModifiedDate);
            command.Parameters.AddWithValue("@CreatorID", subject.Creator.ID);
            command.Parameters.AddWithValue("@IsDeleted", subject.IsDeleted);
        }

        private Subject GetFromReader(SqlDataReader reader)
        {
            Subject subject = new Subject();

            subject.ID = reader.GetInt32("ID");
            subject.Name = reader.GetString("Name");
            subject.LastModifiedDate = reader.GetDateTime("LastModifiedDate");
           
            if (!reader.IsDBNull("CreatorID"))
            {
                subject.Creator = new User()
                {
                    ID = reader.GetInt32("ID")
                };
            }
            
            subject.IsDeleted = reader.GetBoolean("IsDeleted");

            return subject;
        }
    }
}
