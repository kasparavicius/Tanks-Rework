using Classes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TanksRework.Classes.Zemelapis;

namespace TanksRework.Classes
{
    class Facade
    {
        public Langelis CreateKrumas(int x, int y)
        {
            return new Langelis(LangelioTipas.Krumas, x, y);
        }

        public Langelis CreateSiena(int x, int y)
        {
            return new Langelis(LangelioTipas.Siena, x, y);
        }

        public Langelis CreateVanduo(int x, int y)
        {
            return new Langelis(LangelioTipas.Vanduo, x, y);
        }

        public Langelis CreateZeme(int x, int y)
        {
            return new Langelis(LangelioTipas.Zeme, x, y);
        }
    }
}
