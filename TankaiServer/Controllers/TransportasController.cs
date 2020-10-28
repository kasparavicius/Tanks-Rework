using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Classes;
using Antlr.Runtime.Tree;

namespace TankaiServer.Controllers
{
    public class TransportasController : ApiController
    {
        List<Transportas> appVar = System.Web.HttpContext.Current.Application["zaidejai"] as List<Transportas>;
        // GET: api/Transportas
        public List<Transportas> Get()
        {
            return System.Web.HttpContext.Current.Application["zaidejai"] as List<Transportas>;
        }

        // GET: api/Transportas/5
        public string Get(string id)
        {
            return id + "got";
        }

        // POST: api/Transportas
        [System.Web.Http.HttpPost]
        public string Post([FromBody] Transportas value)
        {
            //Transportas trp = JsonConvert.DeserializeObject<Transportas>(value);
            string id = GenerateRandomID(24);
            value.setId(id);
            value.updated = false;

            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"] ?? new List<Transportas>();
            zaidejai.Add(value);
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["zaidejai"] = zaidejai;
            System.Web.HttpContext.Current.Application.UnLock();

            return id;
        }

        // PUT: api/Transportas/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE: api/Transportas/5
        public void Delete(string id)
        {
        }


        private static Random random = new Random();
        private string GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnoprstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(strarray.Length)]).ToArray());
        }

    }
}
