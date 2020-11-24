using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public class SmallFactory : StichijosFactory
    {
        private Random rnd = new Random(69);
        public override Tornadas CreateTornadas()
        {
            return new SmallTornadas(6, rnd.Next(0, 14), rnd.Next(0, 14));
        }
        public override Cunamis CreateCunamis()
        {
            return new SmallCunamis(6, rnd.Next(9, 14), rnd.Next(0, 14));
        }
        public override Drebejimas CreateDrebejimas()
        {
            return new SmallDrebejimas(6, rnd.Next(0, 8), rnd.Next(0, 14));
        }
    }
}
