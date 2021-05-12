using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlQuestionRepository : SqlBaseRepository, IQuestionRepository
    {
        public SqlQuestionRepository(SqlContext context) : base(context)
        {

        }
        public int Add(Question question)
        {
          using(SqlConnection connection=new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Questions output inserted.ID 
                                 values(@ExamID,@Question,@VariantA,@VariantB,@VariantC,
                                 @VariantD,@VariantE,@TrueAnswer,@CreatorID,@LastModifiedDate,@IsDeleted,@SubjectID)";

                using (SqlCommand command = new SqlCommand(cmdText,connection))
                {
                    AddParameters(command, question);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Question question)
        {
            using(SqlConnection connection =new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Update Questions set ExamID=@ExamID,Question=@Question,
                                 VariantA=@VariantA, VariantB=@VariantB, VariantC=@VariantC,
                                 VariantD=@VariantD,VariantE=@VariantE,TrueAnswer=@TrueAnswer,
                                 CreatorID=@CreatorID,LastModifiedDate=@LastModifiedDate,
                                 IsDeleted=@IsDeleted,SubjectID=@SubjectID where ID=@ID";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, question);
                    command.Parameters.AddWithValue("@ID", question.ID);

                    return command.ExecuteNonQuery() == 1;
                }
            }
           
        }

        public List<Question> Get()
        {
           using(SqlConnection connection =new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"select q.* ,s.Name as SubjectName, e.ExamType as ExamType
                                from  Questions as q inner join Exams as e on e.ID=q.ExamID 
                                inner join Subjects as s  on  s.ID=q.SubjectID where q.IsDeleted=0";

                using(SqlCommand command=new SqlCommand(cmdText,connection))
                {
                    List<Question> questions = new List<Question>();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Question question = GetFromReader(reader);               
                        questions.Add(question);
                    }
                    return questions;
                }
            }
        }

        public List<Question> GetByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = "Select * from Questions where IsDeleted=0 order by NEWID()";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    List<Question> questions = new List<Question>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Question question = GetFromReader(reader);
                        questions.Add(question);
                    }
                    return questions;
                }
            }
        }


        private void AddParameters(SqlCommand command, Question question)
        {
            command.Parameters.AddWithValue("@ExamID", question.Exam?.ID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Question", question.Questionn);
            command.Parameters.AddWithValue("@VariantA", question.VariantA);
            command.Parameters.AddWithValue("@VariantB", question.VariantB);
            command.Parameters.AddWithValue("@VariantC", question.VariantC);
            command.Parameters.AddWithValue("@VariantD", question.VariantD);
            command.Parameters.AddWithValue("@VariantE", question.VariantE);
            command.Parameters.AddWithValue("@TrueAnswer", question.TrueAnswer);
            command.Parameters.AddWithValue("@CreatorID", question.Creator.ID);
            command.Parameters.AddWithValue("@LastModifiedDate", question.LastModifiedDate);
            command.Parameters.AddWithValue("@IsDeleted", question.IsDeleted);
            command.Parameters.AddWithValue("@SubjectID", question.Subject?.ID ?? (object)DBNull.Value);

        }

        private Question GetFromReader(SqlDataReader reader)
        {
            Question question = new Question();

            question.ID = reader.GetInt32("ID");

            question.Exam = new Exam1()
            {
                ID = reader.GetInt32("ExamID"),
                ExamType = reader.GetString("ExamType"),
            };

            question.Questionn = reader.GetString("Question");
            question.VariantA = reader.GetString("VariantA");
            question.VariantB = reader.GetString("VariantB");
            question.VariantC = reader.GetString("VariantC");
            question.VariantD = reader.GetString("VariantD");
            question.VariantD = reader.GetString("VariantD");
            question.VariantE = reader.GetString("VariantE");
            question.TrueAnswer = reader.GetString("TrueAnswer");

            question.Subject = new Subject()
            {
                ID = reader.GetInt32("SubjectID"),
                Name = reader.GetString("SubjectName")

            };

            return question;
        }
    }
}
