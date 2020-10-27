using System;
using System.Collections.Generic;
using System.Text;

namespace Classes.Observer
{
    public interface IObserver
    {
        void atnaujinti(List<Transportas> updPriesai);
    }
}
