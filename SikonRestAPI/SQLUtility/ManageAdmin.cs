using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageAdmin
    {
        public static string ConnectionString = ManagementUtil.ConnectionString;
        private const string GET_ALL = "Select * from Admin";
        private const string GET_ONE = "Select * from Admin where UserName = @Name";
        private const string INSERT = "Insert into Room values(@Name, @PhoneNumber)";
        private const string UPDATE = "";
        private const string DELETE = "";

        private Admin readAdmin(SqlDataReader reader)
        {
            Admin admin = new Admin();
            admin.PhoneNumber = reader.GetString(1);

            return admin;
        }



        public Admin Get(string name)
        {
            Admin admin1 = new Admin();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                admin1 = readAdmin(Reader);
            }

            conn.Close();
            return admin1;
        }

        public bool Post(User user)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Name", user.UserName);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            return ok;
        }
    }
}