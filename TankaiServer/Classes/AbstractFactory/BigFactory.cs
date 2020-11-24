using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public class BigFactory : StichijosFactory
    {
        private Random rnd = new Random(1337);
        public override Tornadas CreateTornadas()
        {
            return new BigTornadas(6, rnd.Next(0, 14), rnd.Next(0, 14));
        }
        public override Cunamis CreateCunamis()
        {
            return new BigCunamis(6, rnd.Next(9, 14), rnd.Next(0, 14));
        }
        public override Drebejimas CreateDrebejimas()
        {
            return new BigDrebejimas(6, rnd.Next(0, 8), rnd.Next(0, 14));
        }
    }
}
