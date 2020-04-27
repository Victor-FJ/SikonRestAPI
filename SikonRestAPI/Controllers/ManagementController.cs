using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPI.Controllers
{
    public class ManagementController : ApiController
    {
        //Posts the connectionstring
        //POST: api/Manage/
        [HttpPost]
        [Route("api/Manage/")]
        public bool Post([FromBody] string connectionString)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    ManagementUtil.ConnectionString = connectionString;
                    return true;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
