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
        //public string ConnectionString = "Data Source=nicolaiserver.database.windows.net;Initial Catalog=NicolaiDataBase;User ID=NicolaiAdmin;Password=;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string GET_ALL = "Select * from Speaker";
        private const string GET_ONE = "Select * from Speaker where UserName = @Name";
        private const string INSERT = "Insert into Speaker values(@Name, @FullName, @Desc, @Image";
        private const string UPDATE = "Update Speaker set UserName = @Name, FullName = @FullName, Desription = @Desc, Image_Name = @Image) where UserName = @Name";
        private const string DELETE = "Delete from Speaker where UserNAme = @Name";
        private ManageBasicUser _basicUserManager = new ManageBasicUser();

        private Speaker readSpeaker(SqlDataReader reader)
        {
            Speaker speaker = new Speaker();
            speaker.FullName = reader.GetString(1);
            speaker.Description = reader.GetString(2);
            speaker.Image = reader.GetString(3);

            return speaker;
        }

        public IEnumerable<Speaker> Get()
        {
            List<Speaker> speakerList = new List<Speaker>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Speaker speaker = readSpeaker(reader);
                speakerList.Add(speaker);

            }
            conn.Close();
            return speakerList;
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



        public bool Post(Speaker speaker)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@Name", speaker.UserName);
            cmd.Parameters.AddWithValue("@FullName", speaker.FullName);
            cmd.Parameters.AddWithValue("@Desc", speaker.Description);
            cmd.Parameters.AddWithValue("@Image", speaker.Image);

            _basicUserManager.Post(speaker);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;


            conn.Close();
            return ok;
        }

        public bool Put(Speaker speaker)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@Name", speaker.UserName);
            cmd.Parameters.AddWithValue("@FullName", speaker.FullName);
            cmd.Parameters.AddWithValue("@Desc", speaker.Description);
            cmd.Parameters.AddWithValue("@Image", speaker.Image);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            _basicUserManager.Put(speaker);

            conn.Close();
            return ok;
        }

        public bool Delete(Speaker speaker)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@Name", speaker.UserName);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            _basicUserManager.Delete(speaker);
            
            conn.Close();
            return ok;
        }
    }
}