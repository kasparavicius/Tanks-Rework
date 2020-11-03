using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.AbstractFactory
{
    class SmallTornadas : AbstractTornadas
    {
        public SmallTornadas(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 4;
        }
        public SmallTornadas(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 4;
        }
        public SmallTornadas()
        {
            type = 4;
        }
    }
}