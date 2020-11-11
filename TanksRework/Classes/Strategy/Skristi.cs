using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    class Skristi : IJudejimas
    {
        public (int, int) Move(int x, int y, int posx, int posy, int[,] zemelapis)
        {
            if (posx + x > 14
                || posx + x < 0
                || posy + y > 14
                || posy + y < 0)
            {
                return (posx, posy);
            }
            return (posx += x, posy += y);
        }
    }
}
