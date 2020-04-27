using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary.Model;

namespace SikonRestAPI.Controllers
{
    public class EventController : ApiController
    {
        // GET: api/Event
        public IEnumerable<Event> Get()
        {
            return null;
        }

        // GET: api/Event/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
