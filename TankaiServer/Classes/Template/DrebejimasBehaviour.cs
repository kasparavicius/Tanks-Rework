﻿using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Template
{
    class DrebejimasBehaviour : GamtosBehaviour
    {
        Drebejimas drebejimas;
        public DrebejimasBehaviour(Drebejimas drebejimas)
        {
            this.drebejimas = drebejimas;
        }
        protected override void DealDamage()
        {
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];
            foreach (var item in zaidejai)
            {
                if (item.getPos()[0] >= drebejimas.positionx - 1 && item.getPos()[0] <= drebejimas.positionx + 1 && item.getPos()[1] >= drebejimas.positiony - 1 && item.getPos()[1] <= drebejimas.positiony + 1)
                {
                    if(drebejimas.GetType().Equals(typeof(SmallDrebejimas)))
                    {
                        item.SetHealth(item.GetHealth() - 10);
                    }
                    else
                    {
                        item.SetHealth(item.GetHealth() - 20);
                    }
                }
            }
        }
    }
}