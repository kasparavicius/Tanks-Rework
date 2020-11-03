using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    class SmallDrebejimas : AbstractDrebejimas
    {
        public SmallDrebejimas(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 5;
        }
        public SmallDrebejimas(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 5;
        }
        public SmallDrebejimas()
        {
            type = 5;
        }
    }
}
