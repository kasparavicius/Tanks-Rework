using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Stichijos
{
    public class TornadasBehaviour : GamtosBehaviour
    {
        Tornadas tornadas;
        public TornadasBehaviour(Tornadas tornadas)
        {
            this.tornadas = tornadas;
        }
        protected override void Move()
        {
            Random rnd = new Random(12);
            switch (rnd.Next(1, 4))
            {
                case 1:
                    tornadas.positionx += tornadas.positionx + 1 > 14 ? 0 : 1;
                    tornadas.positiony += tornadas.positiony + 1 > 14 ? 0 : 1;
                    break;
                case 2:
                    tornadas.positionx += tornadas.positionx + 1 > 14 ? 0 : 1;
                    tornadas.positiony -= tornadas.positiony - 1 < 0 ? 0 : 1;
                    break;
                case 3:
                    tornadas.positionx -= tornadas.positionx - 1 < 0 ? 0 : 1;
                    tornadas.positiony += tornadas.positiony + 1 > 14 ? 0 : 1;
                    break;
                case 4:
                    tornadas.positionx -= tornadas.positionx - 1 < 0 ? 0 : 1;
                    tornadas.positiony -= tornadas.positiony - 1 < 0 ? 0 : 1;
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
                if (item.getPos()[0] >= tornadas.positionx - 1 && item.getPos()[0] <= tornadas.positionx + 1 && item.getPos()[1] >= tornadas.positiony - 1 && item.getPos()[1] <= tornadas.positiony + 1)
                {
                    item.SetHealth(item.GetHealth() - tornadas.getDamage());
                }
            }
        }
    }
}