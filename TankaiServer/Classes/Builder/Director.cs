using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.Builder
{
    class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.StartBuild();
        }
    }
}