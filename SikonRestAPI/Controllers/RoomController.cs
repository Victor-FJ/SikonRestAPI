using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary.Model;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPI.Controllers
{
    public class RoomController : ApiController
    {
        private ManageRoom _manager = new ManageRoom();
        // GET: api/Room
        public IEnumerable<Room> Get()
        {
            return _manager.Get();
        }

        // GET: api/Room/5
        public Room Get(string id)
        {
            return _manager.Get(id);
        }

        // POST: api/Room
        public bool Post([FromBody]Room value)
        {
            return _manager.Post(value);
        }

        // PUT: api/Room/5
        public bool Put(string id, [FromBody]Room value)
        {
            return _manager.Put(id, value);
        }

        // DELETE: api/Room/5
        public bool Delete(string id)
        {
            return _manager.Delete(id);
        }
    }
}
