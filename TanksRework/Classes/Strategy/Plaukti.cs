using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    class Plaukti : IJudejimas
    {
        public (int, int) Move(int x, int y, int posx, int posy)
        {
            return (posx += x, posy += y);
        }
    }
}
