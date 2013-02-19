using System.Configuration;
using Autofac;
using MongoDB.Driver;
using Web.Infrastructure.DataStore;

namespace Web.Infrastructure.DependencyInjection.Modules
{
    public class MongoDbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<MongoServer>(x => MongoServerFactory.Build()).SingleInstance();
            builder.Register<MongoDatabase>(x => x.Resolve<MongoServer>().GetDatabase(ConfigurationManager.ConnectionStrings["mongodb"].ProviderName)).InstancePerLifetimeScope();
        }
    }
}