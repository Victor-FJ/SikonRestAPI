using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SikonRestAPI.Controllers
{
    public class AdminsController : ApiController
    {
        // GET: api/Admins
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admins/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admins
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admins/5
        public void Delete(int id)
        {
        }
    }
}
