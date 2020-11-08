using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankaiServer.Classes.Builder
{
    interface IBuilder
    {
        void BuildA();

        void BuildB();
        void StartBuild();
        int[,] GetResult();
    }
}
