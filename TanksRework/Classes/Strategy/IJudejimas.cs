using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    public interface IJudejimas
    {
        // x gali buti -1 arba 1, nuo to priklauso judejimas i kaire ar desine, tas pats su y
        public (int, int) Move(int x, int y, int posx, int posy);
    }
}
