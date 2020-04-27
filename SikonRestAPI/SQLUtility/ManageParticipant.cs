using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageParticipant
    {
        public static string ConnectionString = ManagementUtil.ConnectionString;
        private const string GET_ALL = "Select * from Participant";
        private const string GET_ONE = "Select * from Participant where UserName = @Name";
        private const string INSERT = "Inser into Participant values(@Name, ";
        private const string UPDATE = "";
        private const string DELETE = "";

        private Participant readParticipant(SqlDataReader reader)
        {
            Participant participant = new Participant();
            Enum.TryParse(reader.GetString(1), out participant.Type);


            return participant;
        }



        public Participant Get(string name)
        {
            Participant participant1 = new Participant();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                participant1 = readParticipant(Reader);
            }

            conn.Close();
            return participant1;
        }
    }
}