using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes
{
    public abstract class Transportas
    {
        private String name { get; set; }
        private int healthPoints { get; set; }
        private int damage { get; set; }
        private int level { get; set; }
        public Transportas(String nam, int hp, int dmg, int lvl)
        {
            name = nam;
            healthPoints = hp;
            damage = dmg;
            level = lvl;
        }
    }
}
