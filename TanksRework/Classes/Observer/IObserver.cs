using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Observer
{
    public interface IObserver
    {
        void atnaujinti(List<Transportas> updPriesai);
    }
}
