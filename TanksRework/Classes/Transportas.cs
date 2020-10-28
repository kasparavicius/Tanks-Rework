using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;

namespace Classes
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
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        [JsonProperty]
        public int type { get; set; }
        public Transportas(String nam, int hp, int dmg, int posx, int posy)
        {
            name = nam;
            healthPoints = hp;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Transportas(string id, String nam, int hp, int dmg, int posx, int posy)
        {
            _id = id;
            name = nam;
            healthPoints = hp;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Transportas()
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

        void IObserver.atnaujinti(List<Transportas> updPriesai)
        {
            //Atnaujint info (pos = new pos)
            positionx = updPriesai.Find(p => p.getId() == _id).positionx;
            positiony = updPriesai.Find(p => p.getId() == _id).positiony;
        }
    }
}
