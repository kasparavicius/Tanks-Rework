﻿using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;
using TanksRework.Classes.Strategy;

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
        [JsonProperty]
        public IJudejimas _strategy { get; set; }


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

        public void SetStrategy()
        {
            switch (this.type)
            {

                case 1:
                    {
                        this._strategy = new Skristi();
                        break;
                    }
                case 2:
                    {
                        this._strategy = new Vaziuoti();
                        break;
                    }
                case 3:
                    {
                        this._strategy = new Plaukti();
                        break;
                    }
                default:
                    this._strategy = new Vaziuoti();
                    break;
            }
        }

        public void Move(int x, int y)
        {
            var positions = _strategy.Move(x, y, this.positionx, this.positiony);
            this.positionx = positions.Item1;
            this.positiony = positions.Item2;
        }
    }
}
