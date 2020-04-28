using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using SikonRestAPI.SQLUtility;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageParticipant
    {
        public static string ConnectionString = ManagementUtil.ConnectionString;
        private const string GET_ALL = "Select * from Participant";
        private const string GET_ONE = "Select * from Participant where UserName = @Name";
        private const string INSERT = "Insert into Participant values(@Name, @PersonType)";
        private const string UPDATE = "Update Participant set UserName = @Name, PersonType = @PersonType where UserName = @Name";
        private const string DELETE = "Delete from Participant where UserName = @Name";

        private Participant readParticipant(SqlDataReader reader)
        {
            Participant participant = new Participant();
            Enum.TryParse(reader.GetString(1), out participant.Type);


            return participant;
        }

        public IEnumerable<Participant> Get()
        {
            List<Participant> participantList = new List<Participant>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Participant participant = readParticipant(reader);
                participantList.Add(participant);

            }
            conn.Close();
            return participantList;
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



        public bool Post(Participant participant)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Name", participant.UserName);
            cmd.Parameters.AddWithValue("@PersonType", participant.Type);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            return ok;
        }

        public bool Put(Participant participant)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@Name", participant.UserName);
            cmd.Parameters.AddWithValue("@PersonType", participant.Type);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }

        public bool Delete(Participant participant)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@Name", participant.UserName);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }
    }
}