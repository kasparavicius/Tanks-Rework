using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace TanksRework.Classes.Adapter
{
    [JsonObject(MemberSerialization.OptIn)]
    class RestoreFountain
    {
        [JsonProperty]
        public int HealAmount { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        public RestoreFountain()
        {
            HealAmount = 10;
            positionx = 7;
            positiony = 7;
        }
        public int Restore()
        {
            return HealAmount;
        }
    }
}
