using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Adapter
{
    class RestoreFountainAdapter : Fountain
    {
        RestoreFountain fountain = new RestoreFountain();
        public int Heal()
        {
            return fountain.Restore();
        }
    }
}
