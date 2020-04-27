using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageSpeaker
    {
        public static string ConnectionString = ManagementUtil.ConnectionString;
        private const string GET_ALL = "Select * from Speaker";
        private const string GET_ONE = "Select * from Speaker where UserName = @Name";
        private const string INSERT = "";
        private const string UPDATE = "";
        private const string DELETE = "";

        private Speaker readSpeaker(SqlDataReader reader)
        {
            Speaker speaker = new Speaker();
            speaker.FullName = reader.GetString(1);
            speaker.Description = reader.GetString(2);
            speaker.Image = reader.GetString(3);

            return speaker;
        }



        public Speaker Get(string name)
        {
            Speaker speaker1 = new Speaker();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                speaker1 = readSpeaker(Reader);
            }

            conn.Close();
            return speaker1;
        }
    }
}