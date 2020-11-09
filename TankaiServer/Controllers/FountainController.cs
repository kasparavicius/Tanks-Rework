using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using TankaiServer.Classes.Adapter;

namespace TankaiServer.Controllers
{
    public class FountainController : ApiController
    {
        string healed;
        // GET: api/Fountain
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fountain/5
        public string Get(int id)
        {
            string heal = (string)System.Web.HttpContext.Current.Application["healed"];
            return heal;
        }

        // POST: api/Fountain
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Fountain/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Fountain/5
        public void Delete(int id)
        {
        }
        public void AddNormal()
        {
            IFountain normal = new NormalFountain();

            System.Web.HttpContext.Current.Application["healed"] = normal.Heal();
            healed = normal.Heal();
        }
        public void AddRestore()
        {
            IFountain restore = new RestoreFountainAdapter(new RestoreFountain());

            System.Web.HttpContext.Current.Application["healed"] = restore.Heal();
            healed = restore.Heal();
        }
    }
}
