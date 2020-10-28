using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;

namespace Classes
{
    class TankasTransportas : Transportas
    {
        public TankasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 2;
        }
        public TankasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            type = 2;
        }
        public TankasTransportas()
        {
            type = 2;
        }
    }
}
