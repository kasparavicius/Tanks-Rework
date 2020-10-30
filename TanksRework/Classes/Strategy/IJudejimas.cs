using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    interface IJudejimas
    {
        // x gali buti -1 arba 1, nuo to priklauso judejimas i kaire ar desine, tas pats su y
        public void Move(int x, int y);
    }
}
