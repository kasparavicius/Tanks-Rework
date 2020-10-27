using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Transportas
    {
        [JsonProperty]
        private string _id { get; set; }
        [JsonProperty]
        private string name { get; set; }
        [JsonProperty]
        private int healthPoints { get; set; }
        [JsonProperty]
        private int damage { get; set; }
        [JsonProperty]
        private int[] position { get; set; }
        [JsonProperty]
        public bool updated { get; set; }

        public Transportas(String nam, int hp, int dmg, int[] pos)
        {
            name = nam;
            healthPoints = hp;
            damage = dmg;
            position = pos;
        }

        public string getId()
        {
            return _id;
        }
        public void setId(string id)
        {
            _id = id;
        }

        public int[] getPos()
        {
            return position;
        }
        public void setPos(int[] pos)
        {
            position = pos;
        }
    }
}
