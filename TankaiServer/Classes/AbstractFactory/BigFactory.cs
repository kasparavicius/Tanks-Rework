using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public class BigFactory : StichijosFactory
    {
        public override Tornadas CreateTornadas()
        {
            Random rnd = new Random();
            return new BigTornadas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public override Cunamis CreateCunamis()
        {
            Random rnd = new Random();
            return new BigCunamis(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public override Drebejimas CreateDrebejimas()
        {
            Random rnd = new Random();
            return new BigDrebejimas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
    }
}
