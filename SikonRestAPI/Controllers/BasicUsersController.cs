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
        public User Get(string name, string password)
        {
            return _basicUserManager.Get(name, password);
        }

        // POST: api/BasicUsers
        public void Post([FromBody]User value)
        {
            _basicUserManager.Post(value);
        }

        // PUT: api/BasicUsers/5
        public void Put([FromBody]User value)
        {
            _basicUserManager.Put(value);
        }

        // DELETE: api/BasicUsers/5
        public void Delete(User user)
        {
            _basicUserManager.Delete(user);
        }
    }
}
