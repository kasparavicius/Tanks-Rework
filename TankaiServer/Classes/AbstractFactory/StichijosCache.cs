using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TankaiServer.Classes.AbstractFactory
{
    public class StichijosCache
    {
        private Hashtable cunamiai;
        private Hashtable tornadai;
        private Hashtable drebejimai;

        public Cunamis GetCunamis(string id)
        {
            if (cunamiai.ContainsKey(id))
            {
                Cunamis cachedCunamis = (Cunamis)cunamiai[id];
                return (Cunamis)cachedCunamis.Clone();
            }
            else
            {
                return null;
            }
        }
        public Tornadas GetTornadas(string id)
        {
            if (tornadai.ContainsKey(id))
            {
                Tornadas cachedTornadas = (Tornadas)tornadai[id];
                return (Tornadas)cachedTornadas.Clone();
            }
            else
            {
                return null;
            }
        }
        public Drebejimas GetDrebejimas(string id)
        {
            if (drebejimai.ContainsKey(id))
            {
                Drebejimas cachedDrebejimas = (Drebejimas)drebejimai[id];
                return (Drebejimas)cachedDrebejimas.Clone();
            }
            else
            {
                return null;
            }
        }
        public void loadCache()
        {
            BigFactory bigFactory = new BigFactory();
            SmallFactory smallFactory = new SmallFactory();

            cunamiai = new Hashtable();
            tornadai = new Hashtable();
            drebejimai = new Hashtable();

            Cunamis bCunamis = sukurtiCunami(bigFactory);
            bCunamis.setId("1");
            cunamiai.Add(bCunamis.getId(), bCunamis);

            Cunamis sCunamis = sukurtiCunami(smallFactory);
            sCunamis.setId("2");
            cunamiai.Add(sCunamis.getId(), sCunamis);

            Tornadas bTornadas = sukurtiTornada(bigFactory);
            bTornadas.setId("3");
            tornadai.Add(bTornadas.getId(), bTornadas);

            Tornadas sTornadas = sukurtiTornada(smallFactory);
            sTornadas.setId("4");
            tornadai.Add(sTornadas.getId(), sTornadas);

            Drebejimas bDrebejimas = sukurtiDrebejima(bigFactory);
            bDrebejimas.setId("5");
            drebejimai.Add(bDrebejimas.getId(), bDrebejimas);

            Drebejimas sDrebejimas = sukurtiDrebejima(smallFactory);
            sDrebejimas.setId("6");
            drebejimai.Add(sDrebejimas.getId(), sDrebejimas);
        }

        private Cunamis sukurtiCunami(StichijosFactory factory)
        {
            return factory.CreateCunamis();
        }
        private Tornadas sukurtiTornada(StichijosFactory factory)
        {
            return factory.CreateTornadas();
        }
        private Drebejimas sukurtiDrebejima(StichijosFactory factory)
        {
            return factory.CreateDrebejimas();
        }
    }
}
