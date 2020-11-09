using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TankaiServer.Classes.Adapter
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RestoreFountain
    {
        [JsonProperty]
        public string healamount;
        public string Restore()
        {
           return healamount = "10";
        }
    }
}
