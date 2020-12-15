using System;
using System.Collections.Generic;
using System.Text;
using TanksRework.Classes.Strategy;
using TanksRework.Classes.VisualProxy;

namespace Classes
{
    class LektuvasTransportas : Transportas
    {
        public LektuvasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\plane2d.png");
            type = 3;
            this._strategy = new Skristi();
        }
        public LektuvasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\plane2d.png");
            type = 3;
            this._strategy = new Skristi();
        }
        public LektuvasTransportas()
        {
            this.image = new ProxyImage("assets\\plane2d.png");
            type = 3;
            this._strategy = new Skristi();
        }
    }
}
