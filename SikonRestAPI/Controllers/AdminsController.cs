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
        public void Post([FromBody]Admin value)
        {
            adminManager.Post(value);
        }

        // PUT: api/Admins/5
        public void Put([FromBody]Admin value)
        {
            adminManager.Put(value);
        }

        // DELETE: api/Admins/5
        public void Delete(Admin admin)
        {
            adminManager.Delete(admin); 
        }
    }
}
