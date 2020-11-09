using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TankaiServer.Classes.Adapter
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NormalFountain : IFountain
    {
        [JsonProperty]
        public string healamount;
        public string Heal()
        {
            return healamount = "1";
        }
    }
}
