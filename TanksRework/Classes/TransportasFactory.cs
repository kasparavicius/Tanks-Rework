using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes
{
    public class TransportasFactory
    {
        public Transportas CreateTransportas(int trClass, String trName)
        {
            switch (trClass)
            {

                case 1:
                    {
                        return new LaivasTransportas(trName, 120, 8, 1);
                    }
                case 2:
                    {
                        return new TankasTransportas(trName, 80, 12, 1);
                    }
                case 3:
                    {
                        return new LektuvasTransportas(trName, 100, 10, 1);
                    }
                default:
                    return null;
            }
        }
    }
}
