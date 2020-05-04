using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ModelLibrary.Model;

namespace SikonRestAPI.SQLUtility
{
    /// <summary>
    /// Denne klasse har fået en connection med SQL Databasen, hvor den så laver metoder til
    /// tabellen, der kan fremvise, opdatere, og slette lokaler, de informationer der er lagt eller bliver lagt ud.
    /// </summary>
    public class ManageRoom
    {
        //private string connectRoom = ManagementUtil.ConnectionString;

        private string connectRoom = "";
        //SQL setting call all rooms
        private const string GET_ALL = "select * from room";
        
        //SQL setting call one room
        private const string GET_ONE = "select * from room where Room_No = @RoomNo";
        
        //SQL setting inserts a new room in the database
        private const string INSERT = "INSERT INTO Room VALUES(@RoomNo, @Location, @MaxNoPeople)";
        
        //SQL setting update the change you wrote in a room
        private const string UPDATE = "update room set Room_No = @RoomNo, LocationDes = @Location, MaxNoPeople = @MaxNoPeople where Room_No = @Id";

        //SQL setting delete a room from the database
        private const string DELETE = "delete from room where Room_No = @RoomNo";


        public IEnumerable<Room> Get()
        {
            List<Room> liste = new List<Room>();

            SqlConnection conn = new SqlConnection(connectRoom);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Room room = readRoom(reader);
                liste.Add(room);
            }
            conn.Close();
            return liste;
        }

        private Room readRoom(SqlDataReader reader)
        {
            Room room = new Room();
            room.RoomNo = reader.GetString(0);
            room.LocationDescription = reader.GetString(1);
            room.MaxNoPeople = reader.GetInt32(2);
            return room;
        }


        public Room Get(string roomNo)
        {
            Room room = null;

            SqlConnection conn = new SqlConnection(connectRoom);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@RoomNo", roomNo);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                room = readRoom(reader);
            }
            conn.Close();
            return room;
        }

        public bool Post(Room room)
        {

            SqlConnection conn = new SqlConnection(connectRoom);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@RoomNo", room.RoomNo);
            cmd.Parameters.AddWithValue("@Location", room.LocationDescription);
            cmd.Parameters.AddWithValue("@MaxNoPeople", room.MaxNoPeople);
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = noOfRowsAffected == 1;
            conn.Close();

            return ok;
        }

        public bool Put(string roomNo, Room room)
        {
            

            SqlConnection conn = new SqlConnection(connectRoom);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);

            cmd.Parameters.AddWithValue("@RoomNo", room.RoomNo);
            cmd.Parameters.AddWithValue("@Location", room.LocationDescription);
            cmd.Parameters.AddWithValue("@MaxNoPeople", room.MaxNoPeople);
            cmd.Parameters.AddWithValue("@Id", roomNo);
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = noOfRowsAffected == 1; 
            conn.Close();

            return ok;
        }

        public bool Delete(string roomNo)
        {

            SqlConnection conn = new SqlConnection(connectRoom);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@RoomNo", roomNo);
            int noOfRowsAffected = cmd.ExecuteNonQuery();
           bool ok = noOfRowsAffected == 1;
            conn.Close();

            return ok;

        }
    }

}