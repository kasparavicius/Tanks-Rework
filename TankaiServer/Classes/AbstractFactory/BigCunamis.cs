﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    class BigCunamis : Cunamis
    {
        public BigCunamis(int dmg, int posx, int posy) : base(dmg, posx, posy)
        {
            type = 1;
        }
        public BigCunamis(string id, int dmg, int posx, int posy) : base(id, dmg, posx, posy)
        {
            type = 1;
        }
        public BigCunamis()
        {
            type = 1;
        }
    }
}
