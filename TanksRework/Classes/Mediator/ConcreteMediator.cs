using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Mediator
{
    class ConcreteMediator : IMediator
    {
        private Transportas comp1;
        private Transportas comp2;

        public ConcreteMediator(Transportas puola, Transportas gauna)
        {
            this.comp1 = puola;
            this.comp1.SetMediator(this);
            this.comp2 = gauna;
            this.comp1.SetMediator(this);
        }
        public void Notify(object sender, string ev)
        {
            if (ev == "ATT")
            {
                this.comp2.getDamageTemplate(comp1.damage);
               
                
            }
            if (ev == "HEAL")
            {
                this.comp2.Heal(10);
               
            }
        }
    }
}
