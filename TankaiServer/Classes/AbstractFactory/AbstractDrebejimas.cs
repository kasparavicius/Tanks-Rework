﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TankaiServer.Classes.AbstractFactory
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class AbstractDrebejimas
    {
        [JsonProperty]
        private string _id { get; set; }
        [JsonProperty]
        public int damage { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        [JsonProperty]
        public int type { get; set; }


        public AbstractDrebejimas(int dmg, int posx, int posy)
        {
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public AbstractDrebejimas(string id, int dmg, int posx, int posy)
        {
            _id = id;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public AbstractDrebejimas()
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
    }
}