using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankaiServer.Classes.AbstractFactory
{
    public class TornadasFactory : StichijosFactory
    {
        public AbstractTornadas CreateEvent(int stichijClass)
        {
            Random rnd = new Random();
            switch (stichijClass)
            {

                case 3:
                    {
                        return new BigTornadas(6, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                case 4:
                    {
                        return new SmallTornadas(3, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                default:
                    return null;
            }
        }
    }
}