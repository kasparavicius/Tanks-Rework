using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class TankasTransportas : Transportas
    {
        public TankasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 2;
        }
        public TankasTransportas(string id, bool update, String nam, int hp, int dmg, int posx, int posy) : base(id, update, nam, hp, dmg, posx, posy)
        {
            type = 2;
        }
        public TankasTransportas()
        {
            type = 2;
        }
    }
}
