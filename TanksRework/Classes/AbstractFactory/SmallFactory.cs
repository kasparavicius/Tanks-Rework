using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    public class SmallFactory : StichijosFactory
    {
        public Tornadas CreateTornadas()
        {
            Random rnd = new Random();
            return new SmallTornadas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public Cunamis CreateCunamis()
        {
            Random rnd = new Random();
            return new SmallCunamis(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
        public Drebejimas CreateDrebejimas()
        {
            Random rnd = new Random();
            return new SmallDrebejimas(6, rnd.Next(1, 15), rnd.Next(1, 15));
        }
    }
}
