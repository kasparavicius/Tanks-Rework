using System;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.Adapter
{
    public class RestoreFountainAdapter : IFountain
    {
        public RestoreFountain fountain;
        public RestoreFountainAdapter(RestoreFountain fountain)
        {
            this.fountain = fountain;
        }
        public string Heal()
        {
            return fountain.Restore();
        }
    }
}
