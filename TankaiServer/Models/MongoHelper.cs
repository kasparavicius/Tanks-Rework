using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace TankaiServer.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb+srv://useris3000:slaptazodis@cluster0.jygck.azure.mongodb.net/<dbname>?retryWrites=true&w=majority";
        public static string MongoDatabase = "tankai_db";

        public static IMongoCollection<Models.Tankas> tanks_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}