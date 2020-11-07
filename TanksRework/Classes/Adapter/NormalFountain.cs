using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace TanksRework.Classes.Adapter
{
    [JsonObject(MemberSerialization.OptIn)]
    class NormalFountain
    {
        [JsonProperty]
        private string _id { get; set; }
        [JsonProperty]
        public int HealAmount { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        public NormalFountain(string id, int heal, int posx, int posy)
        {
            _id = id;
            HealAmount = heal;
            positionx = posx;
            positiony = posy;
        }
        public int Heal()
        {
            return HealAmount = 1;
        }
    }
}
