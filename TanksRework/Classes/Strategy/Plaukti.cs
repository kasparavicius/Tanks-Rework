using Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace TanksRework.Classes.Strategy
{
    class Plaukti : IJudejimas
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
            int temp = zemelapis[posx + x, posy + y];
            if (temp == 1
                || temp == 3
                || temp == 4)
            {
                return (posx, posy);
            }
            return (posx += x, posy += y);
        }
    }
}
