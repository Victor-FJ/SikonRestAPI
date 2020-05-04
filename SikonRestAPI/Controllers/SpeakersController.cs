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
    public class SpeakersController : ApiController
    {
        private ManageSpeaker _speakerManager = new ManageSpeaker();
        // GET: api/Speakers
        public IEnumerable<Speaker> Get()
        {
            return _speakerManager.Get();
        }

        // GET: api/Speakers/5
        public Speaker Get(string Name)
        {
            return _speakerManager.Get(Name);
        }

        // POST: api/Speakers
        public void Post([FromBody]Speaker value)
        {
            _speakerManager.Post(value);
        }

        // PUT: api/Speakers/5
        public void Put([FromBody]Speaker value)
        {
            _speakerManager.Put(value);
        }

        // DELETE: api/Speakers/5
        public void Delete(Speaker speaker)
        {
            _speakerManager.Delete(speaker);
        }
    }
}
