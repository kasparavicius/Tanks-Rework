using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    interface IBuilder
    {
        public void BuildA();

        public void BuildB();
        public void StartBuild();
        public Langelis[,] GetResult();
    }
}
