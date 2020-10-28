using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class LektuvasTransportas : Transportas
    {
        public LektuvasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 3;
        }
        public LektuvasTransportas(string id, bool update, String nam, int hp, int dmg, int posx, int posy) : base(id, update, nam, hp, dmg, posx, posy)
        {
            type = 3;
        }
        public LektuvasTransportas()
        {
            type = 3;
        }
    }
}
