using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TanksRework.Classes.VisualProxy
{
    class ProxyImage : ImageInterface
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string filename)
        {
            this.fileName = filename;
        }

        public Image GetImage()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            return realImage.GetImage();
        }

    }
}
