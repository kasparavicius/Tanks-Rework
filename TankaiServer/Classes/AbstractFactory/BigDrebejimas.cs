using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    class BigDrebejimas : Drebejimas
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
