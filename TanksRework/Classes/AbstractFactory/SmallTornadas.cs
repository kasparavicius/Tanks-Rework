using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    class SmallTornadas : Tornadas
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
