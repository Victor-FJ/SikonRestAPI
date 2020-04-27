using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageBasicUser
    {
        public static string ConnectionString = ManagementUtil.ConnectionString;
        private const string GET_ALL = "Select * from BasicUser";
        private const string GET_ONE = "Select * from BasicUser where UserName = @Name and Password = @Password";
        private const string INSERT = "Insert into BasicUser values(@Name, @Password)";
        private const string UPDATE = "Update BasicUser Set UserName = @Name, Password = @Password where UserName = @Name";
        private const string DELETE = "Delete from BasicUser where UserName = @Name and Password = @Password";

        private User readUser(SqlDataReader reader)
        {
            User user = new User();
            user.UserName = reader.GetString(0);
            user.UserName = reader.GetString(1);
            
            return user;
        }

        public IEnumerable<User> Get()
        {
            List<User> userList = new List<User>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = readUser(reader);
                userList.Add(user);

            }
            conn.Close();
            return userList;
        }

        public User Get(string Name, string Password)
        {
            User user1 = new User();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Name",Name);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                user1 = readUser(Reader);
            }

            conn.Close();
            return user1;
        }



        public bool Post(User user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Name", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            return ok;
        }


        public bool Put(User user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@Name", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }

        public bool Delete(User user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@Name", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }


    }
}