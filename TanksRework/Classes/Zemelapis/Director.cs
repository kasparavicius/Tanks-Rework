using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.StartBuild();
        }
    }
}
