using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    class BigTornadas : Tornadas
    {
        public BigTornadas(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 3;
        }
        public BigTornadas(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 3;
        }
        public BigTornadas()
        {
            type = 3;
        }
    }
}
