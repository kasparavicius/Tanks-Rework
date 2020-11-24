using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public class SmallFactory : StichijosFactory
    {
        public override Tornadas CreateTornadas()
        {
            Random rnd = new Random();
            return new SmallTornadas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public override Cunamis CreateCunamis()
        {
            Random rnd = new Random();
            return new SmallCunamis(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public override Drebejimas CreateDrebejimas()
        {
            Random rnd = new Random();
            return new SmallDrebejimas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
    }
}
