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

        private Director director = new Director();

        public Zemelapis()
        {
            IBuilder b1 = new ObstacleBuilder();

            director.Construct(b1);

            langeliai = b1.GetResult();
        }


    }
}
