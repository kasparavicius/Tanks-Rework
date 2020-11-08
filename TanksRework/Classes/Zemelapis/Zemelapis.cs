using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    class Zemelapis
    {
        public int sizeX { get; set; }
        
        public int sizeY { get; set; }

        public Langelis[,] langeliai { get; set; }

        public int[,] matrix { get; set; }


        public Zemelapis()
        {
            sizeX = 15;
            sizeY = 15;
            matrix = new int[sizeX, sizeY];
            langeliai = new Langelis[sizeX, sizeY];
        }


    }
}
