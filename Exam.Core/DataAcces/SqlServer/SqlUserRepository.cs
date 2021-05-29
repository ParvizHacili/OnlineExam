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

                string cmdtext = @"select u.*, ur.ID as UserRoleID, ur.RoleID, r.Name as RoleName
                                  from Users as u Inner Join UserRoles as ur  ON u.ID= ur.UserID
                                  Inner Join Roles as r ON ur.RoleID= r.ID
                                  where u.Username = @username and u.IsDeleted = 0";

                using (SqlCommand command = new SqlCommand(cmdtext, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    var reader = command.ExecuteReader();

                    User user = null;

                    while (reader.Read())
                    {
                        ReadFromReader(reader, ref user);
                    }

                    return user;
                }
            }
        }

        public User Get(int ID)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select u.*, ur.ID as UserRoleID, ur.RoleID, r.Name as RoleName 
                                  from Users as u Inner Join UserRoles as ur  ON u.ID = ur.UserID
                                  Inner Join Roles as r ON ur.RoleID = r.ID
                                  where u.ID = @ID and u.IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    var reader = cmd.ExecuteReader();

                    User user = null;

                    while (reader.Read())
                    {
                        ReadFromReader(reader, ref user);
                    }

                    return user;
                }
            }
        }

        private void ReadFromReader(SqlDataReader reader, ref User user)
        {

            if (user == null)
            {
                user = new User();

                user.ID = reader.GetInt32("ID");
                user.Username = reader.GetString("Username");
                user.Password = reader.GetString("Password");
                user.CanOperateCrm = reader.GetBoolean("CanOperateCrm");
                user.LastModifiedDate = reader.GetDateTime("LastModifiedDate");

                if (!reader.IsDBNull("CreatorID"))
                {
                    user.Creator = new User()
                    {
                        ID = Convert.ToInt32(reader["CreatorID"])
                    };
                }

                user.IsDeleted = reader.GetBoolean("IsDeleted");
            }

            UserRole userRole = new UserRole();

            userRole.ID = reader.GetInt32("UserRoleID");
            userRole.User = user;
            userRole.Role = new Role();
            userRole.Role.ID = reader.GetInt32("RoleID");
            userRole.Role.Name = reader.GetString("RoleName");

            user.UserRoles.Add(userRole);
        }
    }
}
