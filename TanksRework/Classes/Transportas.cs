using System;
using System.Collections.Generic;
using System.Text;
using TanksRework.Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;

namespace TanksRework.Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Transportas : Observer.Subject, Observer.IObserver
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

        void IObserver.atnaujinti(List<Transportas> updPriesai)
        {
            //Atnaujint info (pos = new pos)
            position = updPriesai.Find(p => p.getId() == _id).position;
        }
    }
}
