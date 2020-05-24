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
    public class RegistrationController : ApiController
    {
        private ManageRegistration _manager = new ManageRegistration();

        // GET: api/Registration
        public IEnumerable<Registration> Get()
        {
            return _manager.Get();
        }

        // GET: api/Registration/5
        public Registration Get(int id)
        {
            return _manager.Get(id);
        }

        // POST: api/Registration
        public bool Post([FromBody]Registration value)
        {
            return _manager.Post(value);
        }

        // DELETE: api/Registration/5
        public bool Delete(int id)
        {
            return _manager.Delete(id);
        }

        //CLEAR: api/Registration/Clear/5
        [HttpDelete]
        [Route("api/Registration/ClearEvent/{id}/")]
        public bool ClearEvent(int id)
        {
            return _manager.ClearEvent(id);
        }
    }
}
