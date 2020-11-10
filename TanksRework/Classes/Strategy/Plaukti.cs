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
            int temp = zemelapis[posx + x, posy + y];
            if (temp == 1 || temp == 3 || temp == 4)
            {
                return (posx, posy);
            }
            return (posx += x, posy += y);
        }
    }
}
