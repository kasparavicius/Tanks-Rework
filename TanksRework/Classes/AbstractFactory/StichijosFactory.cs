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
        public abstract Tornadas CreateTornadas();
        public abstract Cunamis CreateCunamis();
        public abstract Drebejimas CreateDrebejimas();
    }
}
