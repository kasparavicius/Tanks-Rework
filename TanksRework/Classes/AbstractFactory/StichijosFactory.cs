using System;
using System.Collections.Generic;
using System.Text;
using Classes.Observer;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharp;
using Newtonsoft.Json;
using TanksRework.Classes.Strategy;

namespace TanksRework.Classes.AbstractFactory
{
    public abstract class StichijosFactory
    {
        public void CreateEvent();
        //AbstractTornadas CreateEvent(1);
        //AbstractDrebejimas CreateEvent();
    }
}
