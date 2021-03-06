﻿using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Strategy
{
    public interface IJudejimas
    {
        // x gali buti -1 arba 1, nuo to priklauso judejimas i kaire ar desine
        // y asis yra apversta. +1 leidziasi juda zemyn, -1 juda aukstyn
        public (int, int) Move(int x, int y, int posx, int posyl, int[,] zemelapis);
    }
}
