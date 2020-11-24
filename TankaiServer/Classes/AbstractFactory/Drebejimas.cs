using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TankaiServer.Classes.AbstractFactory
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Drebejimas
    {
        [JsonProperty]
        private string _id { get; set; }
        [JsonProperty]
        private int damage { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        [JsonProperty]
        public int type { get; set; }


        public Drebejimas(int dmg, int posx, int posy)
        {
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Drebejimas(string id, int dmg, int posx, int posy)
        {
            _id = id;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Drebejimas()
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
        public Drebejimas Clone()
        {
            return (Drebejimas)this.MemberwiseClone();
        }
    }
}
