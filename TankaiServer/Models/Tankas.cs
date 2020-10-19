using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Models
{
    public class Tankas
    {
        public string _id { get; set; }
        public string name { get; set; }
        public int healthPoints { get; set; }
        public int damage { get; set; }
        public int[] position { get; set; }
        public bool updated { get; set; }
    }
}