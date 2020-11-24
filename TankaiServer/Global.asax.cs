using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Classes;
using TankaiServer.Controllers;
using TankaiServer.Classes.Stichijos;
using TankaiServer.Classes.AbstractFactory;
using System.Threading.Tasks;
using System.Timers;

namespace TankaiServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        StichijosCache stichijos;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            
            ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(Transportas), new TransportasBinder()));
            ZemelapisController map = new ZemelapisController();
            FountainController healed = new FountainController();
            
            healed.AddRestore();
            map.StartMap();

            stichijos = new StichijosCache();
            stichijos.loadCache();

            //var x = HttpContext.Current.Application["hello"];

            /*var currContext = HttpContext.Current;

            Timer timer = new Timer(10000);
            timer.Elapsed += async (sender, ee) => await Task.Factory.StartNew(() => {
                StichijosDriver.StartStichijos(currContext, stichijos);
            });
            timer.AutoReset = true;
            timer.Start();*/

        }
    }
}
