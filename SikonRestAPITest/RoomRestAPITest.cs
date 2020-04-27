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
        /// <summary>
        /// 
        /// </summary>
        //[TestMethod]
        //public void RoomtestGetOne()
        //{
        //    //Arrange
        //    ManageRoom manageRoom = new ManageRoom();
        //    Room newRoom = new Room("6A", "Bulevar 66", 20);

        //    //Act
        //    bool ok = manageRoom.PostRoom(newRoom);
        //    manageRoom.Delete("6A");

        //    //Assert
        //    Assert.AreEqual(true, ok);
        //}

        [TestMethod]
        public void RoomtestDelete()
        {
            //Arrange
            ManageRoom manageRoom = new ManageRoom();
            Room newRoom = new Room("6A", "Bulevar 66", 20);
            List<Room> rooms = manageRoom.Get().ToList();
            int antalBeforeDelete = rooms.Count;
            //Act
            bool ok = manageRoom.Post(newRoom);
            rooms = manageRoom.Get().ToList();
            int antalAfterDelete = rooms.Count;

            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(antalBeforeDelete -1, antalAfterDelete);
        }
    }
}
