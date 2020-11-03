using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.AbstractFactory
{
    class BigDrebejimas : AbstractDrebejimas
    {
        public BigDrebejimas(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 5;
        }
        public BigDrebejimas(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 5;
        }
        public BigDrebejimas()
        {
            type = 5;
        }
    }
}