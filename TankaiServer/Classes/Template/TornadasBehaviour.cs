
using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Template
{
    public class TornadasBehaviour : GamtosBehaviour
    {
        Tornadas tornadas;
        public TornadasBehaviour(Tornadas tornadas)
        {
            this.tornadas = tornadas;
        }
        protected void Move()
        {
            tornadas.positionx = tornadas.positionx + 1;
            tornadas.positiony = tornadas.positiony + 1;
        }
        protected override void DealDamage()
        {
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];
            foreach (var item in zaidejai)
            {
                if (item.getPos()[0] >= tornadas.positionx - 1 && item.getPos()[0] <= tornadas.positionx + 1 && item.getPos()[1] >= tornadas.positiony - 1 && item.getPos()[1] <= tornadas.positiony + 1)
                {
                    if (tornadas.GetType().Equals(typeof(SmallDrebejimas)))
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