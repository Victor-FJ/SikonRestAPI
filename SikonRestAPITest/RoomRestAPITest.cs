using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary.Model;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPITest
{
    [TestClass]
   public class RoomRestApiTest
    {
        
        [TestMethod]
        public void RoomtestPostTest()
        {
            //Arrange
            ManagementUtil.ConnectionString = "Data Source = nicolaiserver.database.windows.net; Initial Catalog = NicolaiDataBase; User ID = NicolaiAdmin; Password = Seacret1234; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
            ManageRoom manageRoom = new ManageRoom();
            Room newRoom = new Room("6A", "Bulevar 66", 20);

            //Act
            bool ok = manageRoom.Post(newRoom);
            manageRoom.Delete("6A");

            //Assert
            Assert.AreEqual(true, ok);
        }

        //[TestMethod]
        //public void RoomtestDelete()
        //{
        //    //Arrange
        //    ManageRoom manageRoom = new ManageRoom();
        //    Room newRoom = new Room("6A", "Bulevar 66", 20);
        //    List<Room> rooms = manageRoom.Get().ToList();
        //    int antalBeforeDelete = rooms.Count;
        //    //Act
        //    bool ok = manageRoom.Post(newRoom);
        //    rooms = manageRoom.Get().ToList();
        //    int antalAfterDelete = rooms.Count;

        //    //Assert
        //    Assert.AreEqual(true, ok);
        //    Assert.AreEqual(antalBeforeDelete -1, antalAfterDelete);
        //}
    }
}
