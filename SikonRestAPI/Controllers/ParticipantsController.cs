using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using ModelLibrary.Model;
using SikonRestAPI.SQLUtility;

namespace SikonRestAPI.Controllers
{
    public class ParticipantsController : ApiController
    {
        private ManageParticipant _participantManager = new ManageParticipant();
        // GET: api/Participants
        public IEnumerable<Participant> Get()
        {
            return _participantManager.Get();
        }

        // GET: api/Participants/5
        public Participant Get(string Name)
        {
            return _participantManager.Get(Name);
        }

        // POST: api/Participants
        public bool Post([FromBody]Participant value)
        {
            return _participantManager.Post(value);
        }

        // PUT: api/Participants/5
        public bool Put([FromBody]Participant value)
        {
            return _participantManager.Put(value);
        }

        // DELETE: api/Participants/5
        public bool Delete(Participant participant)
        {
            return _participantManager.Delete(participant);
        }
    }
}
