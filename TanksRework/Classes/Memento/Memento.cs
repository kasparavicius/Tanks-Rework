using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Memento
{
    class Memento
    {
        private int posx;
        private int posy;

        public Memento(int x, int y)
        {
            posx = x;
            posy = y;
        }

        public (int, int) getSavedPosition()
        {
            return (posx, posy);
        }
    }
}
