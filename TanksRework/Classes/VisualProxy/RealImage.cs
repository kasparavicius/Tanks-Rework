using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TanksRework.Classes.VisualProxy
{
    class RealImage : ImageInterface
    {
        private Image image;

        public RealImage(string filename)
        {
            this.image = new Bitmap(filename);
        }

        public Image GetImage()
        {
            return image;
        }
    }
}
