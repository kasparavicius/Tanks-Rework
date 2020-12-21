using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankaiRework.ER
{
    public class KulkosFlyweightFactory
    {
        private List<Tuple<KulkosFlyweight, string>> flyweights = new List<Tuple<KulkosFlyweight, string>>();

        public KulkosFlyweightFactory(params Kulkos[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<KulkosFlyweight, string>(new KulkosFlyweight(elem), this.getKey(elem)));
            }
        }

        public string getKey(Kulkos key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.texture);

            //elements.Sort();

            return string.Join("_", elements);
        }

        public KulkosFlyweight GetKulkosFlyweight(Kulkos sharedState)
        {
            string key = this.getKey(sharedState);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                this.flyweights.Add(new Tuple<KulkosFlyweight, string>(new KulkosFlyweight(sharedState), key));
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }
    }
}
