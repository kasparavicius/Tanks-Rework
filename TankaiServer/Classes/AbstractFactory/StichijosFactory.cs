using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public abstract class StichijosFactory
    {
        public abstract Tornadas CreateTornadas();
        public abstract Cunamis CreateCunamis();
        public abstract Drebejimas CreateDrebejimas();
    }
}
