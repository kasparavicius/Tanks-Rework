using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.AbstractFactory
{
    class BigCunamis : AbstractCunamis
    {
        public BigCunamis(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 1;
        }
        public BigCunamis(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 1;
        }
        public BigCunamis()
        {
            type = 1;
        }
    }
}