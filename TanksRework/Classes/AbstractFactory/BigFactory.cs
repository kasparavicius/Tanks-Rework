using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    public class BigFactory : StichijosFactory
    {
        public Tornadas CreateTornadas()
        {
            Random rnd = new Random();
            return new BigTornadas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public Cunamis CreateCunamis()
        {
            Random rnd = new Random();
            return new BigCunamis(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public Drebejimas CreateDrebejimas()
        {
            Random rnd = new Random();
            return new BigDrebejimas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
    }
}
