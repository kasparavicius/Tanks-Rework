using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Adapter
{
    class RestoreFountainAdapter : IFountain
    {
        public RestoreFountain fountain;
        public RestoreFountainAdapter(RestoreFountain fountain)
        {
            this.fountain = fountain;
        }
        public int Heal()
        {
            return fountain.Restore();
        }
    }
}
