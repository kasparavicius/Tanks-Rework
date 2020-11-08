using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Zemelapis
{
    class Zemelapis
    {
        public int sizeX { get; set; }
        
        public int sizeY { get; set; }

        public Langelis[,] langeliai { get; set; }

        public int[,] matrix { get; set; }


        public Zemelapis(int[,] matrix)
        {
            sizeX = matrix.GetLength(0);
            sizeY = matrix.GetLength(1);
            this.matrix = matrix;
            langeliai = new Langelis[sizeX, sizeY];
            MatrixToLangelis();
        }

        private void MatrixToLangelis()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    switch (matrix[i, j])
                    {
                        case 1:
                            this.langeliai[i, j] = new Langelis(LangelioTipas.Zeme, i, j);
                            break;
                        case 2:
                            this.langeliai[i, j] = new Langelis(LangelioTipas.Vanduo, i, j);
                            break;
                        case 3:
                            this.langeliai[i, j] = new Langelis(LangelioTipas.Siena, i, j);
                            break;
                        case 4:
                            this.langeliai[i, j] = new Langelis(LangelioTipas.Krumas, i, j);
                            break;
                        case 5:
                            this.langeliai[i, j] = new Langelis(LangelioTipas.Powerup, i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


    }
}
