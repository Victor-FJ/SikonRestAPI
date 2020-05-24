using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    public class ManageRegistration
    {
        private const string GetAllCmd = "SELECT * FROM Registration";
        private const string GetOneCmd = "SELECT * FROM Registration WHERE Id = @Id";
        private const string InsertCmd = "INSERT INTO Registration VALUES(@Registration_No, @UserName, @EventId);";
        private const string DeleteCmd = "DELETE FROM Registration WHERE Id = @Id;";
        private const string ClearEventCmd = "DELETE FROM Registration WHERE EventId = @EventId;";

        public IEnumerable<Registration> Get()
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetAllCmd, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Registration> list = new List<Registration>();
                        while (reader.Read())
                        {
                            Registration registration = ReadRegistration(reader);
                            list.Add(registration);
                        }

                        return list;
                    }
                }
            }
        }

        public Registration Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetOneCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return ReadRegistration(reader);
                        return null;
                    }
                }
            }
        }

        private Registration ReadRegistration(SqlDataReader reader)
        {
            return new Registration(reader.GetInt32(0), 
                reader.GetString(1), reader.GetInt32(2));
        }


        public bool Post(Registration registration)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(InsertCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Registration_No", registration.Id);
                    cmd.Parameters.AddWithValue("@UserName", registration.UserName);
                    cmd.Parameters.AddWithValue("@EventId", registration.EventId);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();

                    return noOfRowsAffected == 1;
                }
            }
        }


        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();

                    return noOfRowsAffected == 1;
                }
            }
        }

        public bool ClearEvent(int eventId)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(ClearEventCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

    }
}