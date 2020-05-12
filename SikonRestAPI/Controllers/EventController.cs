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
    public class EventController : ApiController
    {
        private readonly ManageEvent _manager = new ManageEvent();

        // GET: api/Event
        public IEnumerable<Event> Get()
        {
            return _manager.Get();
        }

        // GET: api/Event/5
        public Event Get(int id)
        {
            return _manager.Get(id);
        }

        // POST: api/Event
        public bool Post([FromBody]Event value)
        {
            return _manager.Post(value);
        }

        // PUT: api/Event/5
        public bool Put(int id, [FromBody]Event value)
        {
            return _manager.Put(id, value);
        }

        // DELETE: api/Event/5
        public bool Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
