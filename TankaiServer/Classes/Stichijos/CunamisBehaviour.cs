using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Stichijos
{
    public class CunamisBehaviour : GamtosBehaviour
    {
        Cunamis cunamis;
        public CunamisBehaviour(Cunamis cunamis)
        {
            this.cunamis = cunamis;
        }
        protected override void Move()
        {
            Random rnd = new Random(555);
            switch (rnd.Next(1, 4))
            {
                case 1:
                    cunamis.positionx += cunamis.positionx + 1 > 14 ? 0 : 1;
                    cunamis.positiony += cunamis.positiony + 1 > 14 ? 0 : 1;
                    break;
                case 2:
                    cunamis.positionx += cunamis.positionx + 1 > 14 ? 0 : 1;
                    cunamis.positiony -= cunamis.positiony - 1 < 0 ? 0 : 1;
                    break;
                case 3:
                    cunamis.positionx -= cunamis.positionx - 1 < 9 ? 0 : 1;
                    cunamis.positiony += cunamis.positiony + 1 > 14 ? 0 : 1;
                    break;
                case 4:
                    cunamis.positionx -= cunamis.positionx - 1 < 9 ? 0 : 1;
                    cunamis.positiony -= cunamis.positiony - 1 < 0 ? 0 : 1;
                    break;
                default:
                    break;
            }
        }
        protected override void DealDamage()
        {
            List<Transportas> zaidejai = (List<Transportas>)System.Web.HttpContext.Current.Application["zaidejai"];
            foreach (var item in zaidejai)
            {
                if (item.getPos()[0] >= cunamis.positionx - 1 && item.getPos()[0] <= cunamis.positionx + 1 && item.getPos()[1] >= cunamis.positiony - 1 && item.getPos()[1] <= cunamis.positiony + 1)
                {
                    item.SetHealth(item.GetHealth() - cunamis.getDamage());
                }
            }
        }
    }
}