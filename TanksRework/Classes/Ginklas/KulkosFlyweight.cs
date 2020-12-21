using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TankaiRework.ER
{
    public class KulkosFlyweight
    {
        private Kulkos _sharedState;

        public KulkosFlyweight(Kulkos kulka)
        {
            this._sharedState = kulka;
        }

        public string Operation(Kulkos uniqueState)
        {
            string s = JsonConvert.SerializeObject(this._sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);

            return ($"Shared state {s}, unique state {u}");
        }
    }
}
