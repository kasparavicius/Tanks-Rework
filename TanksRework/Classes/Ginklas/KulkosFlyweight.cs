using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Tuple<int, int, Image> Operation(Kulkos uniqueState)
        {
            //string s = JsonConvert.SerializeObject(this._sharedState);
            //string u = JsonConvert.SerializeObject(uniqueState);

            //return ($"Shared state {s}, unique state {u}");
            return new Tuple<int, int, Image>(uniqueState.cordx, uniqueState.cordy, _sharedState.texture);
        }
    }
}
