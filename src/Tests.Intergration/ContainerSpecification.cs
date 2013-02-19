using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using Web.Infrastructure.DataStore;
using Web.Infrastructure.DependencyInjection.Modules;

namespace Tests.Intergration
{
    [SetUpFixture]
    public class ContainerSpecification
    {
        private static IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _container = BuildContainer();
        }

        [TearDown]
        public void TearDown()
        {

        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MongoDbModule>();
            builder.RegisterModule<RepositoryModule>();

            var container = builder.Build();

            return container;
        }
    }
}
