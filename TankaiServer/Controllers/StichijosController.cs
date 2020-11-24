using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Classes.Messages;

namespace TankaiServer.Controllers
{
    public class StichijosController : ApiController
    {
        // GET: api/Stichijos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stichijos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stichijos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stichijos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stichijos/5
        public void Delete(int id)
        {
        }
    }
}
