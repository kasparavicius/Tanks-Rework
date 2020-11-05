using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;
using TanksRework.Classes.Strategy;

namespace TanksRework.Classes.AbstractFactory
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Tornadas
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


        public Tornadas(int dmg, int posx, int posy)
        {
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Tornadas(string id, int dmg, int posx, int posy)
        {
            _id = id;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Tornadas()
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
        public Tornadas Clone()
        {
            return (Tornadas)this.MemberwiseClone();
        }
    }
}
