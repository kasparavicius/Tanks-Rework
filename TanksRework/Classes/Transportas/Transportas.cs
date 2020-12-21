using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;
using TanksRework.Classes.Strategy;
using System.Drawing;
using TanksRework.Classes.VisualProxy;
using TanksRework.Classes.Memento;

namespace Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Transportas : Observer.Subject, Observer.IObserver
    {
        [JsonProperty]
        public string _id { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public int healthPoints { get; set; }
        [JsonProperty]
        private int damage { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        [JsonProperty]
        public int type { get; set; }
        [JsonProperty]
        public IJudejimas _strategy { get; set; }

        public ImageInterface image = new ProxyImage("assets\\tankas2d.png");

        List<Memento> mementos = new List<Memento>();


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

        public string getName()
        {
            return name;
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
            //if nera tokio id sarase, pridedam prie observeriu?
        }

        public void Move(int x, int y, int[,] zemelapis)
        {
            Memento temp = new Memento(this.positionx, this.positiony);
            mementos.Add(temp);
            var positions = _strategy.Move(x, y, this.positionx, this.positiony, zemelapis);
            this.positionx = positions.Item1;
            this.positiony = positions.Item2;
        }

        public void MementoMethod()
        {
            var temp = mementos[mementos.Count - 5].getSavedPosition();
            this.positionx = temp.Item1;
            this.positiony = temp.Item2;
        }

        public bool CanYouDoMemento()
        {
            return mementos.Count >= 5;
        }
    }
}
