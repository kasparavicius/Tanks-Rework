using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    class SmallDrebejimas : Drebejimas
    {
        public SmallDrebejimas(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 6;
        }
        public SmallDrebejimas(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 6;
        }
        public SmallDrebejimas()
        {
            type = 6;
        }
    }
}
