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
        
        public Langelis(LangelioTipas tipas, int X, int Y)
        {
            Tipas = tipas;
            pozicijaX = X;
            pozicijaY = Y;
        }
    }
}
