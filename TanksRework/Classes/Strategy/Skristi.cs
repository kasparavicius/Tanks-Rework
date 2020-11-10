using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    class Skristi : IJudejimas
    {
        public (int, int) Move(int x, int y, int posx, int posy, int[,] zemelapis)
        {
            return (posx += x, posy += y);
        }
    }
}
