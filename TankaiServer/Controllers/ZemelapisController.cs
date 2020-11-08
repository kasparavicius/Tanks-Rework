﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using TankaiServer.Classes.Builder;

namespace TankaiServer.Controllers
{
    public class ZemelapisController : ApiController
    {
        int[,] map;
        Director director = new Director();
        // GET: api/Zemelapis
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET: api/Zemelapis/5
        public object Get(int id)
        {
            return System.Web.HttpContext.Current.Application["map"];
        }

        // POST: api/Zemelapis
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Zemelapis/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Zemelapis/5
        public void Delete(int id)
        {
        }

        public void StartMap()
        {
            IBuilder b1 = new ObstacleBuilder(map);
            director.Construct(b1);
            System.Web.HttpContext.Current.Application["map"] = b1.GetResult();
            map = b1.GetResult();
        }
    }
}
