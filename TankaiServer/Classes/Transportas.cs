using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Transportas
    {
        [JsonProperty]
        public string _id { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public int healthPoints { get; set; }
        [JsonProperty]
        public int damage { get; set; }
        [JsonProperty]
        public int positionx { get; set; }
        [JsonProperty]
        public int positiony { get; set; }
        [JsonProperty]
        public bool updated { get; set; }
        [JsonProperty]
        public int type { get; set; }

        public Transportas(String nam, int hp, int dmg, int posx, int posy)
        {
            name = nam;
            healthPoints = hp;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Transportas(string id, bool update, String nam, int hp, int dmg, int posx, int posy)
        {
            _id = id;
            updated = update;
            name = nam;
            healthPoints = hp;
            damage = dmg;
            positionx = posx;
            positiony = posy;
        }
        public Transportas()
        {

        }

        public string getId()
        {
            return _id;
        }
        public void setId(string id)
        {
            _id = id;
        }

        public int[] getPos()
        {

            return new int[] { positionx, positiony };
        }
        public void setPos(int[] pos)
        {
            positionx = pos[0];
            positiony = pos[1];
        }
    }

    public class TransportasBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var values = (ValueProviderCollection)bindingContext.ValueProvider;

            //var age = (int)values.GetValue("Age").ConvertTo(typeof(int));
            //var name = (string)values.GetValue("Name").ConvertTo(typeof(string));

            if (values.GetValue("_id") != null)
            {
                var _id = (string)values.GetValue("_id").ConvertTo(typeof(string));
                var updated = (bool)values.GetValue("updated").ConvertTo(typeof(bool));
                var name = (string)values.GetValue("name").ConvertTo(typeof(string));
                var healthPoints = (int)values.GetValue("healthPoints").ConvertTo(typeof(int));
                var damage = (int)values.GetValue("damage").ConvertTo(typeof(int));
                var positionx = (int)values.GetValue("positionx").ConvertTo(typeof(int));
                var positiony = (int)values.GetValue("positiony").ConvertTo(typeof(int));
                var type = (int)values.GetValue("type").ConvertTo(typeof(int));
                //return name == "labas" ? (Transportas)new LaivasTransportas { _id = _id, damage = damage, type = type, healthPoints = healthPoints, name = name, positionx = positionx, positiony = positiony, updated = updated } : new TankasTransportas { _id = _id, damage = damage, type = type, healthPoints = healthPoints, name = "kazkas", positionx = positionx, positiony = positiony, updated = updated };
                switch (type)
                {
                    case 1:
                        {
                            return (Transportas)new LaivasTransportas(_id, updated, name, healthPoints, damage, positionx, positiony);
                        }
                    case 3:
                        {
                            return (Transportas)new LektuvasTransportas(_id, updated, name, healthPoints, damage, positionx, positiony);
                        }
                    default:
                            return (Transportas)new TankasTransportas(_id, updated, name, healthPoints, damage, positionx, positiony);
                }
            }
            else
            {
                var name = (string)values.GetValue("name").ConvertTo(typeof(string));
                var healthPoints = (int)values.GetValue("healthPoints").ConvertTo(typeof(int));
                var damage = (int)values.GetValue("damage").ConvertTo(typeof(int));
                var positionx = (int)values.GetValue("positionx").ConvertTo(typeof(int));
                var positiony = (int)values.GetValue("positiony").ConvertTo(typeof(int));
                var type = (int)values.GetValue("type").ConvertTo(typeof(int));
                //return type == 1 ? (Transportas)new LaivasTransportas(name, healthPoints, damage, positionx, positiony) : new TankasTransportas("kazkas", healthPoints, damage, positionx, positiony);
                switch (type)
                {
                    case 1:
                        {
                            return (Transportas)new LaivasTransportas(name, healthPoints, damage, positionx, positiony);
                        }
                    case 3:
                        {
                            return (Transportas)new LektuvasTransportas(name, healthPoints, damage, positionx, positiony);
                        }
                    default:
                            return (Transportas)new TankasTransportas(name, healthPoints, damage, positionx, positiony);
                }
            }
        }

    }
}
