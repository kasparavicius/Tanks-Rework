using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.Builder
{
    public class ObstacleBuilder : IBuilder
    {
        private int[,] map = new int[15, 15];
        Random rnd = new Random();
        public ObstacleBuilder(int[,] matrix)
        {
            //map = matrix;
        }
        public void BuildA()
        {
            for (int k = 0; k < map.GetLength(0); k++)
            {
                for (int l = 0; l < map.GetLength(1); l++)
                {
                    map[k, l] = 1;
                }
            }
            for (int k = map.GetLength(0) - 6; k < map.GetLength(0); k++)
            {
                for (int l = 0; l < map.GetLength(1); l++)
                {
                    map[k, l] = 2;
                }
            }
        }

        public void BuildB()
        {
            int i = 0;
            float count = map.GetLength(0) * map.GetLength(1) / 5;
            while(i < count)
            {
                map[rnd.Next(0, map.GetLength(0)), rnd.Next(0, map.GetLength(1))] = 3;

                i++;
            }

            i = 0;

            while (i < count / 2)
            {
                map[rnd.Next(0, map.GetLength(0)), rnd.Next(0, map.GetLength(1))] = 4;

                i++;
            }
        }

        public int[,] GetResult()
        {
            return map;
        }

        public void StartBuild()
        {
            BuildA();
            BuildB();
        }
    }
}