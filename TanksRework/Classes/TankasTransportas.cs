﻿using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;

namespace Classes
{
    class TankasTransportas : Transportas
    {
        public TankasTransportas(String nam, int hp, int dmg, int[] pos) : base(nam, hp, dmg, pos)
        {
        }
    }
}
