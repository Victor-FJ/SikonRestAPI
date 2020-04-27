using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SikonRestAPI.SQLUtility
{
    public class ImageManager
    {
        private const string GetNamesCmd = "SELECT Name FROM Image;";
        private const string GetOneCmd = "SELECT Data FROM Image WHERE Name = @Name;";
        private const string InsertCmd = "INSERT INTO Image VALUES(@Name, @Data);";
        private const string DeleteCmd = "DELETE FROM Image WHERE Name = @Name;";

        public IEnumerable<string> GetNames()
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetNamesCmd, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> list = new List<string>();
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }

                        return list;
                    }
                }
            }
        }

        public byte[] Get(string name)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetOneCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    return cmd.ExecuteScalar() as byte[];
                }
            }
        }

        public bool Post(string name, byte[] pixelBytes)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(InsertCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Data", pixelBytes);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();
                    return noOfRowsAffected == 1;
                }
            }
        }

        public bool Delete(string name)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();
                    return noOfRowsAffected == 1;
                }
            }
        }
    }
}