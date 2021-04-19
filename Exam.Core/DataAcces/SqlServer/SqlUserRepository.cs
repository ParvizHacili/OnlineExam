using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Exam.Core.Domain.Enums;
using System;
using System.Collections.Generic;
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

                        user.ID = Convert.ToInt32(reader["ID"]);
                        user.Name = Convert.ToString(reader["Name"]);
                        user.Surname = Convert.ToString(reader["Surname"]);
                        user.Username = Convert.ToString(reader["Username"]);
                        user.Password = Convert.ToString(reader["Password"]);
                        user.Gender = (Gender)Convert.ToInt32(reader["Gender"]);
                        user.Email = Convert.ToString(reader["Email"]);
                        user.Phone = Convert.ToString(reader["Phone"]);
                        user.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        user.Type = (UserType)Convert.ToInt32(reader["Type"]);
                        user.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);

                        if (!reader.IsDBNull(reader.GetOrdinal("CreatorID")))
                        {
                            user.Creator = new User()
                            {
                                ID = Convert.ToInt32(reader["CreatorID"])
                            };
                        }
                        user.CanOperateCrm = Convert.ToBoolean(reader["CanOperateCrm"]);
                        user.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
