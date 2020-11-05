using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    class SmallCunamis : Cunamis
    {
        public SmallCunamis(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 2;
        }
        public SmallCunamis(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 2;
        }
        public SmallCunamis()
        {
            type = 2;
        }
    }
}
