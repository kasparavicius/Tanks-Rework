using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.Builder
{
    public class PowerUpBuilder : IBuilder
    {
        public int[,] map;
        Random rnd = new Random();

        public PowerUpBuilder(int[,] matrix)
        {
            map = matrix;
        }
        public void BuildA()
        {
            int i = 0;
            while(i < 3)
            {
                map[rnd.Next(0, 15), rnd.Next(0, 15)] = 5;
                i++;
            }
        }

        public void BuildB()
        {
            
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