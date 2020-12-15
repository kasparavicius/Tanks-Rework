using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using TanksRework.Classes.Strategy;
using TanksRework.Classes.VisualProxy;

namespace Classes
{
    class TankasTransportas : Transportas
    {
        public TankasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }
        public TankasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }
        public TankasTransportas()
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }
    }
}
