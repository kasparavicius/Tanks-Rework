using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    class ObstacleBuilder : IBuilder
    {
        private Langelis[,] result;

        private int xSize;
        private int ySize;
        private int CountOfItems = 6;

        Facade facade = new Facade();
        Random rnd = new Random();

        public void BuildA()
        {
            
            int i = 0;

            while(i < CountOfItems)
            {
                int x = rnd.Next(1, xSize);
                int y = rnd.Next(1, ySize);

                result[x, y] = facade.CreateSiena(x, y);

                i++;
            }

            i = 0;

            while (i < CountOfItems)
            {
                int x = rnd.Next(1, xSize);
                int y = rnd.Next(1, ySize);

                result[y, x] = facade.CreateKrumas(y, x);

                i++;
            }
        }

        public void BuildB()
        {
            for (int y = 17; y < 24; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    result[x, y] = facade.CreateVanduo(x, y);
                }
            }
        }

        public Langelis[,] GetResult()
        {
            return result;
        }

        public void StartBuild()
        {
            xSize = 24;
            ySize = 14;
            BuildA();
            BuildB();
        }
    }
}
