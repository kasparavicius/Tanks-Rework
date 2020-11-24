using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TankaiServer.Classes.AbstractFactory
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Cunamis : Stichija
    {
        [JsonProperty]
        private string _id { get; set; }
        [JsonProperty]
        private int damage { get; set; }
        [JsonProperty]
        public int type { get; set; }


        public Cunamis(int dmg, int posx, int posy)
        {
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Cunamis(string id, int dmg, int posx, int posy)
        {
            _id = id;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Cunamis()
        {

        }
        public string getId()
        {
            return _id;
        }
        public void setId(string id)
        {
            _id = id;
        }
        public int getDamage()
        {
            return damage;
        }
        public Cunamis Clone()
        {
            return (Cunamis)this.MemberwiseClone();
        }
    }
}
