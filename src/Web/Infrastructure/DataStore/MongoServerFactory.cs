using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Web.Infrastructure.DataStore
{
    public class MongoServerFactory
    {
        public static MongoServer Build()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString;
            var client = new MongoClient(connectionString);

            return client.GetServer();
        }
    }
}