using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.AbstractFactory
{
    public class DrebejimasFactory : StichijosFactory
    {
        public AbstractDrebejimas CreateEvent(int stichijClass)
        {
            Random rnd = new Random();
            switch (stichijClass)
            {

                case 5:
                    {
                        return new BigDrebejimas(6, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                case 6:
                    {
                        return new SmallDrebejimas(3, rnd.Next(1, 15), rnd.Next(1, 15));
                    }
                default:
                    return null;
            }
        }
    }
}
