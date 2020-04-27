using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPI.Controllers
{
    public class ImageController : ApiController
    {
        private static readonly ImageManager Manager = new ImageManager();

        //Gets all image names
        //GET: api/Image
        [HttpGet]
        [Route("api/Image")]
        public IEnumerable<string> GetNames()
        {
            return Manager.GetNames();
        }

        //Gets requested images
        //GET: api/Image/{name}
        [HttpGet]
        [Route("api/Image/{name}")]
        public byte[] Get(string name)
        {
            byte[] test = Manager.Get(name);
            return test;
        }

        [HttpPost]
        [Route("api/Image/{name}")]
        public bool Post(string name, [FromBody] byte[] pixelBytes)
        {
            return Manager.Post(name, pixelBytes);
        }

        [HttpDelete]
        [Route("api/Image/{name}")]
        public bool Delete(string name)
        {
            return Manager.Delete(name);
        }
    }
}
