using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPI.SQLUtility
{
    public class ManageEvent
    {
        private const string GetAllCmd = "SELECT * FROM Event";
        private const string GetOneCmd = "SELECT * FROM Event WHERE Event_id = @Id";
        private const string InsertCmd = "INSERT INTO Event VALUES(@Event_No, @Title, @Description, @Type, @Subject, @MaxNoParticipant, @StartDate, @EndDate, @Room_No, @Speaker, @Image_Name);";
        private const string UpdateCmd = "UPDATE Event SET Title = @Title, Description = @Description, Type = @Type, Subject = @Subject, MaxNoParticipant = @MaxNoParticipant, StartDate = @StartDate, EndDate = @EndDate, Room_No = @Room_No, Speaker = @Speaker, Image_Name = @Image_Name WHERE Id = @Id;";
        private const string DeleteCmd = "DELETE FROM Event WHERE Id = @Id;";

        public IEnumerable<Event> Get()
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetAllCmd, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Event> list = new List<Event>();
                        while (reader.Read())
                        {
                            Event eventSi = ReadEvent(reader);
                            list.Add(eventSi);
                        }

                        return list;
                    }
                }
            }
        }

        public Event Get(int id)
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
                            return ReadEvent(reader);
                        return null;
                    }
                }
            }
        }

        private Event ReadEvent(SqlDataReader reader)
        {
            Event eventSi = new Event();
            eventSi.Id = reader.GetInt32(0);
            eventSi.Title = reader.GetString(1);
            eventSi.Description = reader.GetString(2);

            Enum.TryParse(reader.GetString(3), out Event.EventType type);
            eventSi.Type = type;
            Enum.TryParse(reader.GetString(4), out Event.EventSubject subject);
            eventSi.Subject = subject;
            eventSi.MaxNoParticipant = reader.GetInt32(5);

            eventSi.StartDate = reader.GetDateTime(6);
            eventSi.EndDate = reader.GetDateTime(7);


            eventSi.Room = new ManageRoom().Get(reader.GetString(8));
            eventSi.Speaker = new ManageSpeaker().Get(reader.GetString(9));
            eventSi.ImageName = reader.GetString(10);

            return eventSi;
        }


        public bool Post(Event eventSi)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(InsertCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", eventSi.Id);
                    cmd.Parameters.AddWithValue("@Title", eventSi.Title);
                    cmd.Parameters.AddWithValue("@Description", eventSi.Description);
                    cmd.Parameters.AddWithValue("@Type", eventSi.Type);
                    cmd.Parameters.AddWithValue("@Subject", eventSi.Subject);
                    cmd.Parameters.AddWithValue("@MaxNoParticipant", eventSi.MaxNoParticipant);
                    cmd.Parameters.AddWithValue("@StartDate", eventSi.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", eventSi.EndDate);
                    cmd.Parameters.AddWithValue("@Room_No", eventSi.Room.RoomNo);
                    cmd.Parameters.AddWithValue("@Speaker", eventSi.Speaker.UserName);
                    cmd.Parameters.AddWithValue("@Image_Name", eventSi.ImageName);
                    int noOfRowsAffected = cmd.ExecuteNonQuery();

                    return noOfRowsAffected == 1;
                }
            }
        }


        public bool Put(int id, Event eventSi)
        {
            using (SqlConnection conn = new SqlConnection(ManagementUtil.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Event_No", eventSi.Id);
                    cmd.Parameters.AddWithValue("@Title", eventSi.Title);
                    cmd.Parameters.AddWithValue("@Description", eventSi.Description);
                    cmd.Parameters.AddWithValue("@Type", eventSi.Type);
                    cmd.Parameters.AddWithValue("@Subject", eventSi.Subject);
                    cmd.Parameters.AddWithValue("@MaxNoParticipant", eventSi.MaxNoParticipant);
                    cmd.Parameters.AddWithValue("@StartDate", eventSi.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", eventSi.EndDate);
                    cmd.Parameters.AddWithValue("@Room_No", eventSi.Room.RoomNo);
                    cmd.Parameters.AddWithValue("@Speaker", eventSi.Speaker.UserName);
                    cmd.Parameters.AddWithValue("@Image_Name", eventSi.ImageName);

                    cmd.Parameters.AddWithValue("@Id", id);
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
    }
}