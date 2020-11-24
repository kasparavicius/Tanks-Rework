using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Template
{
    public class CunamisBehaviour : GamtosBehaviour
    {
        Cunamis cunamis;
        public CunamisBehaviour(Cunamis cunamis)
        {
            this.cunamis = cunamis;
        }
        protected void Move()
        {
            if (cunamis.positionx >= 9 && cunamis.positionx <= 13 && cunamis.positiony >= 0 && cunamis.positiony <= 13)
            {
                cunamis.positionx = cunamis.positionx + 1;
                cunamis.positiony = cunamis.positiony + 1;
            }
        }
        protected override void DealDamage()
        {
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];
            foreach (var item in zaidejai)
            {
                if (item.getPos()[0] >= cunamis.positionx - 1 && item.getPos()[0] <= cunamis.positionx + 1 && item.getPos()[1] >= cunamis.positiony - 1 && item.getPos()[1] <= cunamis.positiony + 1)
                {
                    if (cunamis.GetType().Equals(typeof(SmallCunamis)))
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