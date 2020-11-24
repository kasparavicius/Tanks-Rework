using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Template
{
    public abstract class GamtosBehaviour
    {
        protected abstract void DealDamage();
        public void Execute()
        {
            Move();
            DealDamage();
        }
        protected void Move()
        {

        }
    }
}