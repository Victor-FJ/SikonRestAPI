using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SikonRestAPI.Controllers
{
    public class BasicUsersController : ApiController
    {
        // GET: api/BasicUsers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BasicUsers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BasicUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BasicUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BasicUsers/5
        public void Delete(int id)
        {
        }
    }
}
