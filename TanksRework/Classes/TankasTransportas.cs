using System;
using System.Collections.Generic;
using System.Text;
using TanksRework.Classes.Observer;

namespace TanksRework.Classes
{
    class TankasTransportas : Transportas
    {
        internal TankasTransportas(String nam, int hp, int dmg, int[] pos) : base(nam, hp, dmg, pos)
        {
        }
    }
}
