using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Stichijos
{
    public abstract class GamtosBehaviour
    {
        protected abstract void DealDamage();
        public void Execute()
        {
            this.Move();
            //DealDamage();
        }
        protected virtual void Move()
        {

        }
    }
}