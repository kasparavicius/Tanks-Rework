using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class LaivasTransportas : Transportas
    {
        public LaivasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 1;
        }
        public LaivasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            type = 1;
        }
        public LaivasTransportas()
        {
            type = 1;
        }
    }
}
