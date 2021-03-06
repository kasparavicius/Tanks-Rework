﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class TransportasFactory
    {
        public Transportas CreateTransportas(int trClass, String trName)
        {
            Random rnd = new Random();
            switch (trClass)
            {

                case 1:
                    {
                        return new LaivasTransportas(trName, 120, 8, rnd.Next(1, 15), rnd.Next(1, 15) );
                    }
                case 2:
                    {
                        return new TankasTransportas(trName, 80, 12, rnd.Next(1, 15), rnd.Next(1, 15) );
                    }
                case 3:
                    {
                        return new LektuvasTransportas(trName, 100, 10, rnd.Next(1, 15), rnd.Next(1, 15) );
                    }
                default:
                    return null;
            }
        }
    }
}
