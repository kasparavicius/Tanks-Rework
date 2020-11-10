using System;
using System.Collections.Generic;
using System.Text;
using TanksRework.Classes.Strategy;

namespace Classes
{
    class LaivasTransportas : Transportas
    {
        public LaivasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            type = 1;
            this._strategy = new Plaukti();
        }
        public LaivasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            type = 1;
            this._strategy = new Plaukti();
        }
        public LaivasTransportas()
        {
            type = 1;
            this._strategy = new Plaukti();
        }
    }
}
