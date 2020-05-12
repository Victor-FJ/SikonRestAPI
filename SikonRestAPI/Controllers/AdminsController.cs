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
    public class AdminsController : ApiController
    {
        ManageAdmin adminManager = new ManageAdmin();
        // GET: api/Admins
        public IEnumerable<Admin> Get()
        {
            return adminManager.Get();
        }

        // GET: api/Admins/5
        public Admin Get(string Name)
        {
            return adminManager.Get(Name);
        }

        // POST: api/Admins
        public bool Post([FromBody]Admin value)
        {
            return adminManager.Post(value);
        }

        // PUT: api/Admins/5
        public bool Put([FromBody]Admin value)
        {
            return adminManager.Put(value);
        }

        // DELETE: api/Admins/5
        public bool Delete(Admin admin)
        {
           return adminManager.Delete(admin); 
        }
    }
}
