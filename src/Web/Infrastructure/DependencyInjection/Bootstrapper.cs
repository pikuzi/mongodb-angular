using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Web.Infrastructure.DependencyInjection.Modules;

namespace Web.Infrastructure.DependencyInjection
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer Startup(HttpConfiguration httpConfiguration)
        {
            _container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            //_container.Resolve<IEnumerable<DelegatingHandler>>().ForEach(httpConfiguration.MessageHandlers.Add);

            return _container;
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<MongoDbModule>();
            builder.RegisterModule<RepositoryModule>();

            return builder.Build();
        }
    }
}