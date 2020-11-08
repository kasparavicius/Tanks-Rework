using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    class Langelis
    {
        public LangelioTipas Tipas { get; set; }
        public int pozicijaX {get;set;}
        public int pozicijaY { get; set; }

        public string imageLoc { get; set; }
        
        public Langelis(LangelioTipas tipas, int X, int Y)
        {
            Tipas = tipas;
            pozicijaX = X;
            pozicijaY = Y;

            setimageLoc();
        }

        private void setimageLoc()
        {
            switch (Tipas)
            {
                case LangelioTipas.Zeme:
                    this.imageLoc = "assets\\ground.png";
                    break;
                case LangelioTipas.Vanduo:
                    this.imageLoc = "assets\\water.png";
                    break;
                case LangelioTipas.Siena:
                    this.imageLoc = "assets\\wall.png";
                    break;
                case LangelioTipas.Krumas:
                    this.imageLoc = "assets\\bush.png";
                    break;
                case LangelioTipas.Powerup:
                    this.imageLoc = "assets\\powerup.png";
                    break;
                default:
                    break;
            }
        }
    }
}
