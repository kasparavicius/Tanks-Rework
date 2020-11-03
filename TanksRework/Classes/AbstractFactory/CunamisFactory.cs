using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    public class CunamisFactory : StichijosFactory
    {
        public AbstractCunamis CreateEvent(int stichijClass)
        {
            Random rnd = new Random();
            switch (stichijClass)
            {

                case 1:
                    {
                        return new BigCunamis(6, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                case 2:
                    {
                        return new SmallCunamis(3, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                default:
                    return null;
            }
        }
    }
}
