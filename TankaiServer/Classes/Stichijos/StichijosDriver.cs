using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Timers;
using System.Web.Http;
using Classes.Messages;
using TankaiServer.Classes.AbstractFactory;

namespace TankaiServer.Classes.Stichijos
{
    public class StichijosDriver
    {
        private static int i = 0;
        private static Timer timer;

        private static readonly Random _random = new Random();

        //private static Stichija stich;
        //private static GamtosBehaviour behaviour;

        public static void StartStichijos(HttpContext context, StichijosCache stichijos)
        {
            Message msg = new Message();
            msg._id = "123";
            msg.name = "Serveris";
            msg.message = "Starting stichijos";

            List<Message> messages = (List<Message>)context.Application["messages"] ?? new List<Message>();

            messages.Add(msg);
            context.Application.Lock();
            context.Application["messages"] = messages;
            context.Application.UnLock();

        
            Stichija stich = null;
            GamtosBehaviour behaviour = null;
            switch (_random.Next(1, 6))
            {
                case 1:
                    stich = stichijos.GetCunamis("1");
                    behaviour = new CunamisBehaviour((Cunamis)stich);
                    break;
                case 2:
                    stich = stichijos.GetCunamis("2");
                    behaviour = new CunamisBehaviour((Cunamis)stich);
                    break;
                case 3:
                    stich = stichijos.GetTornadas("3");
                    behaviour = new TornadasBehaviour((Tornadas)stich);
                    break;
                case 4:
                    stich = stichijos.GetTornadas("4");
                    behaviour = new TornadasBehaviour((Tornadas)stich);
                    break;
                case 5:
                    stich = stichijos.GetDrebejimas("5");
                    behaviour = new DrebejimasBehaviour((Drebejimas)stich);
                    break;
                case 6:
                    stich = stichijos.GetDrebejimas("6");
                    behaviour = new DrebejimasBehaviour((Drebejimas)stich);
                    break;
                default:
                break;
            }



            i = 0;
            timer = new Timer(2500);
            timer.Elapsed += (sender, e) => DoStuff(sender, e, context, stich, behaviour);
            timer.AutoReset = true;
            timer.Start();
        }

        private static void DoStuff(Object source, ElapsedEventArgs e, HttpContext context, Stichija stich, GamtosBehaviour behaviour)
        {
            i++;

            if (i >= 3)
            {
                timer.Stop();
                timer.Elapsed -= (sender, ee) => DoStuff(sender, e, context, stich, behaviour); 
                timer.Dispose(); 
                timer = null;
            }

            behaviour.Execute();

            Message msg = new Message();
            msg._id = "123";
            msg.name = "Serveris";
            msg.message = stich.GetType().ToString() + " juda " + stich.positionx + "," + stich.positiony;

            List<Message> messages = (List<Message>)context.Application["messages"] ?? new List<Message>();

            messages.Add(msg);
            context.Application.Lock();
            context.Application["messages"] = messages;
            context.Application.UnLock();
        }
    }
}