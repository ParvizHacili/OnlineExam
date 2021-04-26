using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Exam.Core.Domain.Enums;
using Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Exam.Core.DataAcces.SqlServer
{
    public class SqlUserRepository : SqlBaseRepository, IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context)
        {

        }
        public User Get(string username)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdtext = @"Select * from Users where Username=@username
                                           and IsDeleted=0 ";

                using (SqlCommand command = new SqlCommand(cmdtext, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        User user = new User();

                        user.ID = reader.GetInt32("ID");
                        user.Name = reader.GetString("Name");
                        user.Surname = reader.GetString("Surname");
                        user.Username = reader.GetString("Username");
                        user.Password = reader.GetString("Password");
                        user.Gender = (Gender)reader.GetInt32("Gender");
                        user.Email = reader.GetString("Email");
                        user.Phone = reader.GetString("Phone");
                        user.BirthDate = reader.GetDateTime("BirthDate");
                        user.Type = (UserType)reader.GetInt32("Type");
                        user.LastModifiedDate = reader.GetDateTime("LastModifiedDate");

                        if (!reader.IsDBNull("CreatorID"))
                        {
                            user.Creator = new User()
                            {
                                ID = reader.GetInt32("CreatorID")
                            };
                        }
                        user.CanOperateCrm = reader.GetBoolean("CanOperateCrm");
                        user.IsDeleted = reader.GetBoolean("IsDeleted");

                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
