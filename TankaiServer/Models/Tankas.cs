using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Models
{
    public class Tankas
    {
        public Object _id { get; set; }
        public int pozicijax { get; set; }
        public int pozicijay { get; set; }
        public string pavadinimas { get; set; }
        public int metai { get; set; }
    }
}