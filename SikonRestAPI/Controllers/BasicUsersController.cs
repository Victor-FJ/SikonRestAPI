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
    public class BasicUsersController : ApiController
    {
        private ManageBasicUser _basicUserManager = new ManageBasicUser();
        // GET: api/BasicUsers
        public IEnumerable<User> Get()
        {
            return _basicUserManager.Get();
        }

        // GET: api/BasicUsers/5
        public User Get(string name)
        {
            return _basicUserManager.Get(name);
        }

        // POST: api/BasicUsers
        public bool Post([FromBody]User value)
        {
            return _basicUserManager.Post(value);
        }

        // PUT: api/BasicUsers/5
        public bool Put([FromBody]User value)
        {
            return _basicUserManager.Put(value);
        }

        // DELETE: api/BasicUsers/5
        public bool Delete(User user)
        {
            return _basicUserManager.Delete(user);
        }
    }
}
