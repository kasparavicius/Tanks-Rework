using System;
using System.Collections.Generic;
using System.Text;
using TanksRework.Classes.Strategy;

namespace Classes
{
    class LektuvasTransportas : Transportas
    {
        public LektuvasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 3;
            this._strategy = new Skristi();
        }
        public LektuvasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            type = 3;
            this._strategy = new Skristi();
        }
        public LektuvasTransportas()
        {
            type = 3;
            this._strategy = new Skristi();
        }
    }
}
