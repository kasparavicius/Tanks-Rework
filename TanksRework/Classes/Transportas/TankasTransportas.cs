using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using TanksRework.Classes.Strategy;
using TanksRework.Classes.VisualProxy;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Classes
{
    class TankasTransportas : Transportas
    {
        public TankasTransportas(String nam, int hp, int dmg, int posx, int posy) : base(nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }
        public TankasTransportas(string id, String nam, int hp, int dmg, int posx, int posy) : base(id, nam, hp, dmg, posx, posy)
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }
        public TankasTransportas()
        {
            this.image = new ProxyImage("assets\\tankas2d.png");
            type = 2;
            this._strategy = new Vaziuoti();
        }

        public override void GetDamage(int dmg)
        {
            healthPoints -= dmg;
            
        }

        public override void UpdateEnemyHealthPoints()
        {
            IRestClient restas = new RestClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };
            //playeris = new TransportasFactory().CreateTransportas(comboBox1.SelectedIndex + 1, textBox2.Text);

            restas.UseNewtonsoftJson();

            //Postinam savo pozicija
            IRestRequest request = new RestRequest()
            {
                Resource = "https://localhost:44356/Tankas/DealDamage/"
            };

            var test = JsonConvert.SerializeObject(this, Formatting.Indented, serializerSettings);
            // test.Content = test.Content.Replace("TanksRework", "TankaiServer");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            //request.AddJsonBody(test);
            request.AddParameter("application/json", test, ParameterType.RequestBody);

            restas.Post<string>(request);
        }
    }
}
